using SRL.Data_Access.Entity;
using SRL.Data_Access.Resources;
using SRL.Models;
using SRL.Models.ActorMasterData;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace SRL.Data_Access.Adapter
{
    public static class ActorAdapter
    {
        public static List<Actor> ConvertActorList(this IEnumerable<API_LIST_ACTORS_TRANSACTION_Result> actorListResult)
        {
            List<Actor> actorList = new List<Actor>();
            foreach (var alr in actorListResult)
            {
                Actor actor = new Actor();
                actor.ActorId = alr.ACTOR_ID;
                actor.ActorLabel = alr.ACTOR_LABEL;
                actor.FromTo = alr.FROM_TO;

                actorList.Add(actor);
            }
            return actorList;
        }

        public static List<ActorMasterListResponse> ConvertActorMasterList(this IEnumerable<API_LIST_ACTOR_MASTERDATA_Result> result)
        {
            List<ActorMasterListResponse> actorsList = new List<ActorMasterListResponse>();
            foreach (var actor in result)
            {
                actorsList.Add(new ActorMasterListResponse
                {
                    ActorCode = actor.ACTOR_CODE,
                    ActorId = actor.ACTOR_ID,
                    ActorName = actor.ACTOR_NAME,
                    ActorLocation = actor.ACTOR_LOCATION,
                    ActorType = actor.ACTOR_TYPE,
                    RetailerChain = actor.RETAILER_CHAIN
                });
            }

            return actorsList;
        }

        public static ActorDetailResponse ConvertActorDetail(this List<API_ACTOR_MASTERDATA_DETAILS_Result> results)
        {
            if (results.Any())
            {
                var result = results.FirstOrDefault();

                return new ActorDetailResponse()
                {
                    ActorId = result.ACTOR_ID,
                    ActorCode = result.ACTOR_CODE,
                    ActorName = result.ACTOR_NAME,
                    ActorTypeId = result.ACTOR_TYPE_ID,
                    ActorTypeName = result.ACTOR_TYPE_NAME,
                    RetailerChainId = result.RETAILER_CHAIN_ID ?? -1,
                    DefaultLanguageCodeId = result.DEFAULT_LANGUAGE_CODE_ID ?? 0,
                    Language = result.LANGUAGE,
                    ActorIPAddress = result.ACTOR_IP_ADRESS,
                    EmergencyQuantity = result.QTY_EMERGENCY ?? 0,
                    DummyActorReferenceId = result.DUMMY_ACTOR_REFERENCE_ID ?? 0,
                    DummyActorName = result.DUMMY_ACTOR,
                    LabelType = result.LABEL_TYPE,
                    NovexxClientCode = result.NOVEXX_CLIENT_CODE ?? 0,
                    NumberOfLabels = result.NUMBER_OF_LABELS ?? 0,
                    CardboardBox = result.CARDBOARD_BOX ?? 0,
                    ActorDeliveryId = result.ACTOR_DELIVERY ?? 0
                };
            }
            else
                return new ActorDetailResponse();
        }

        public static Dictionary<string, string> ConvertActorLabelType()
        {
            Dictionary<string, string> labelTypes = new Dictionary<string, string>();
            System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(Resources.ActorLabelType));
            ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            IDictionaryEnumerator id = resourceSet.GetEnumerator();
            while (id.MoveNext())
            {
                labelTypes.Add(id.Key.ToString(), id.Value.ToString());
            }
            resourceSet.Close();
            return labelTypes;
        }

        public static List<Actor_SLA> ConvertToSLAsForActor(this List<API_SLA_LIST_PER_RETAILER_Result> result)
        {
            List<Actor_SLA> actorSLAs = new List<Actor_SLA>();
            result.ForEach(sla => actorSLAs.Add(sla.ConvertToActorSLA()));
            return actorSLAs;

        }

        private static Actor_SLA ConvertToActorSLA(this API_SLA_LIST_PER_RETAILER_Result result)
        {
            return new Actor_SLA()
            {
                 LoadUnitSLAId = result.LOAD_UNIT_SLA_ID,
                 LoadUnitId = result.LOAD_UNIT_ID,
                 LoadUnitCode = result.LOAD_UNIT_CODE,
                 RTIAcceptance = result.RTI_ACCEPTANCE,
                 Linked = result.LINKED == 1 ? true : false
            };
        }
    }
}
