using SRL.Data_Access.Adapter;
using SRL.Data_Access.Repository;
using SRL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// Controller for all Actor related actions
    /// </summary>
    public class ActorController : ApiController
    {
        private readonly ActorRepository _actorRepository = new ActorRepository();
        /// <summary>
        /// Get the list of actors for a given retailerchain
        /// default = -1; all chains
        /// </summary>
        /// <param name="retailerChainId"></param>
        /// <returns></returns>
        public List<Actor> GetActors(int retailerChainId = -1)
        {
            return ActorAdapter.ConvertActorList(_actorRepository.GetActorList(retailerChainId));
        }
    }
}