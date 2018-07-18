using SRL_Portal_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SRL_Portal_API.Controllers
{
    public class ActorController : ApiController
    {
        [System.Web.Http.HttpGet]
        public IList<API_LIST_ACTORS_TRANSACTION_Result> Get()
        {
            BACKUP_SRL_20180613Entities dbEntities = new BACKUP_SRL_20180613Entities();

            var result = dbEntities.API_LIST_ACTORS_TRANSACTION(-1)
                .ToList<API_LIST_ACTORS_TRANSACTION_Result>();

            return result;
        }

        [HttpGet]
        public IList<API_LIST_ACTORS_TRANSACTION_Result> Post(bool fromTo)
        {
            BACKUP_SRL_20180613Entities dbEntities = new BACKUP_SRL_20180613Entities();

            var result = dbEntities.API_LIST_ACTORS_TRANSACTION(-1)
                .ToList<API_LIST_ACTORS_TRANSACTION_Result>();

            return result.Where(x =>
            {
                var value = fromTo ? 1 : 0;
                return x.FROM_TO == value;
            }).ToList();
        }
    }
}