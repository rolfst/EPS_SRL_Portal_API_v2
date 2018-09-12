using System.Collections.Generic;
using SRL.Data_Access.Entity;
using SRL.Models.ActorMasterData;
using SRL.Data_Access.Adapter;
using SRL.Models;
using System.Linq;
using System.Resources;
using System.Globalization;
using System.Collections;
using System;

namespace SRL.Data_Access.Repository
{
    public class ActorRepository
    {
        public IEnumerable<API_LIST_ACTORS_TRANSACTION_Result> GetActorList(int retailerChainId)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                IEnumerable<API_LIST_ACTORS_TRANSACTION_Result> result = dbEntity.API_LIST_ACTORS_TRANSACTION(retailerChainId);
                return result;
            }
        }

        public List<Actor> GetActorsList(string userEmail)
        {
            List<Actor> actors = new List<Actor>();
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                actors = dbEntity.API_LIST_ACTORS_TRANSACTION(-1).ConvertActorList();
            }
            //Fetch actors for logged in user
            UserRepository userRepository = new UserRepository();
            //Fetch actors assigned to the user
            List<int> actorIdList = userRepository.GetActorIdList(userEmail);
            List<Actor> actorsList = new List<Actor>();
            if (actorIdList.Any())
            {
                foreach (var actorId in actorIdList)
                {
                    Actor actor = actors.FirstOrDefault(a => a.ActorId == actorId);
                    if (actor != null)
                        actorsList.Add(actor);
                }
                return actorsList;
            }
            else
                return actors;

        }


        public List<ActorMasterListResponse> GetActorMasterDataList(ActorMasterListRequest request)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                IEnumerable<API_LIST_ACTOR_MASTERDATA_Result> result = dbEntity.API_LIST_ACTOR_MASTERDATA(request.ActorName, request.ActorCode, request.RetailerChainId, request.Location);
                return result.ConvertActorMasterList();
            }
        }

        public Dictionary<string, string> GetLabelTypes()
        {
            return ActorAdapter.ConvertActorLabelType();
        }

        public ActorDetailResponse GetActorDetail(int actorId)
        {
            ActorDetailResponse actorDetail = new ActorDetailResponse();
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                actorDetail = dbEntity.API_ACTOR_MASTERDATA_DETAILS(actorId).ToList().ConvertActorDetail();
                actorDetail.SLAs = dbEntity.API_SLA_LIST_PER_RETAILER(actorDetail.RetailerChainId, actorId).ToList().ConvertToSLAsForActor();
            }

            return actorDetail;
        }

        public bool SaveActorMaster(AddActorDetailRequest request)
        {
            int result = SaveActorMasterDetail(request);
            if (result > 0)
            {
                request.ActorId = request.ActorId.HasValue && request.ActorId > 0 ? request.ActorId : result;
                return SaveActorSLAs(request);
            }
            return false;
        }

        private int SaveActorMasterDetail(AddActorDetailRequest request)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                return dbEntity.API_ADD_ACTOR_MASTERDATA(request.ActorId, request.ActorTypeId, request.ActorCode, request.RetailerChainId, request.DefaultLanguageCodeId,
                     request.DefaultLanguageCode, request.ActorIPAddress, request.EmergencyStockQty, request.DummyActorReferenceId, request.LabelType,
                     request.NOVEXXClientCode, request.NumberOfLabel, request.CardboardBox, request.ActorDeliveryId, request.CurrentUser).FirstOrDefault().ACTOR_ID ?? 0;
                
            }
        }

        private bool SaveActorSLAs(AddActorDetailRequest request)
        {
            Int32 actorId = request.ActorId ?? 0;
            if (actorId > 0)
            {
                //Copy SLA of the source actor
                if (request.CopySLAActorId.HasValue)
                {
                    using (var dbEntity = new BACKUP_SRL_20180613Entities())
                    {
                        dbEntity.API_INSERT_ACTOR_SLA_FROM_SRC_ACTOR(request.ActorId, request.CopySLAActorId, request.CurrentUser);
                    }
                }
                else if (request.SLAs.Any())
                {
                    request.SLAs.ForEach(s => { SaveSLA(s, actorId, request.CurrentUser); });
                }

                return true;
            }
            else
            {
                return false;
            }
        }


    private int SaveSLA(Actor_SLA_Request actor_SLA, int actorId, string currentUser)
    {
        using (var dbEntity = new BACKUP_SRL_20180613Entities())
        {
            return dbEntity.API_SLA_INSERT(actor_SLA.LoadUnitId, actorId, actor_SLA.RTIAcceptance, currentUser, actor_SLA.StandardSLA).FirstOrDefault() ?? 0;
        }
    }
}
}
