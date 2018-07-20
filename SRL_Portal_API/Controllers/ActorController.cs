using SRL.Data_Access.Adapter;
using SRL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Repository;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// Controller for all Actor related actions
    /// </summary>
    public class ActorController : ApiController
    {
        /// <summary>
        /// Get all distinct actors
        /// </summary>
        /// <returns>a list of Actors</returns>
        [HttpPost]
        public IList<API_LIST_ACTORS_TRANSACTION_Result> Get()
        {
            var dbEntities = new BACKUP_SRL_20180613Entities();

            var result = dbEntities.API_LIST_ACTORS_TRANSACTION(-1);

            return result.DistinctBy(x => x.ACTOR_ID).ToList();
        }

        /// <summary>
        /// Get actors based on destination.
        /// </summary>
        /// <param name="fromTo"><c>True</c> if it's a From Actor, <c>False</c> if it's a To Actor</param>
        /// <returns>a list of Actors depending on the destination (from/to)</returns>
        [HttpPost]
        public IList<API_LIST_ACTORS_TRANSACTION_Result> GetOnDestination(bool fromTo)
        {
            var dbEntities = new BACKUP_SRL_20180613Entities();

            var result = dbEntities.API_LIST_ACTORS_TRANSACTION(-1);

            return result.Where(x =>
            {
                var value = fromTo ? 1 : 0;
                return x.FROM_TO == value;
            }).ToList();
        }

        /// <summary>
        /// Get the list of actors for a given retailerchain
        /// default = -1; all chains
        /// </summary>
        /// <param name="retailerChainId"></param>
        /// <returns></returns>
        public List<Actor> GetActors(int retailerChainId = -1)
        {
            var repo = new ActorRepository();
            return ActorAdapter.ConvertActorList(repo.GetActorList(retailerChainId));
        }
    }
}