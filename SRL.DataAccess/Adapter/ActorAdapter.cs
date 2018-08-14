using SRL.Data_Access.Entity;
using SRL.Models;
using SRL.Models.ActorMasterData;
using System.Collections.Generic;

namespace SRL.Data_Access.Adapter
{
    public static class ActorAdapter
    {
        public static List<Actor> ConvertActorList(IEnumerable<API_LIST_ACTORS_TRANSACTION_Result> actorListResult)
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

        public static List<ActorMasterListResponse>ConvertActorMasterList(this IEnumerable<API_LIST_ACTOR_MASTERDATA_Result> result)
        {
            List<ActorMasterListResponse> actorsList = new List<ActorMasterListResponse>();
            foreach(var actor in result)
            {
                actorsList.Add(new ActorMasterListResponse {
                     ActorCode = actor.ACTOR_CODE,
                     ActorId = actor.ACTOR_ID,
                      ActorName =actor.ACTOR_NAME,
                      ActorLocation = actor.ACTOR_LOCATION,
                      ActorType=actor.ACTOR_TYPE,
                      RetailerChain = actor.RETAILER_CHAIN
                });
            }

            return actorsList;
        }
    }
}
