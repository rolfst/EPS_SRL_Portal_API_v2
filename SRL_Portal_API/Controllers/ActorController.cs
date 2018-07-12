using SRL.Data_Access.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// Controller for Actor-based calls
    /// </summary>
    public class ActorController : ApiController
    {
        /// <summary>
        /// Get the list of actors for a given Retail Chain
        /// </summary>
        /// <param name="retailChainId"></param>
        /// <returns>List of actors</returns>
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IList<API_LIST_ACTORS_TRANSACTION_Result> Index(int retailChainId = -1)
        {
            BACKUP_SRL_20180613Entities dbEntities = new BACKUP_SRL_20180613Entities();

            var result = dbEntities.API_LIST_ACTORS_TRANSACTION(retailChainId)
                .ToList<API_LIST_ACTORS_TRANSACTION_Result>();

            return result;
        }
    }
}