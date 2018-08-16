using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using SRL.Data_Access.Entity;

namespace SRL_Portal_API.Controllers
{
    [EnableCors(origins: "http://localhost:9005", headers: "*", methods: "*")]
    public class CarrierController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public IList<API_LIST_LOAD_CARRIER_Result> Index()
        {
            BACKUP_SRL_20180613Entities dbEntities = new BACKUP_SRL_20180613Entities();

            var result = dbEntities.API_LIST_LOAD_CARRIER()
                .ToList<API_LIST_LOAD_CARRIER_Result>();

            return result;
        }
    }
}