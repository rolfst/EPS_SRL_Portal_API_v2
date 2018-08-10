using SRL.Data_Access.Entity;
using SRL.Models;
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
    }
}
