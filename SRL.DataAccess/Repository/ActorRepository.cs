using System.Collections.Generic;
using SRL.Data_Access.Entity;
using SRL.Models.ActorMasterData;
using SRL.Data_Access.Adapter;
using SRL.Models;
using System.Linq;

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
            UserRespository userRespository = new UserRespository();
            //Fetch actors assigned to the user
            List<int> actorIdList = userRespository.GetActorIdList(userEmail);
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
    }
}
