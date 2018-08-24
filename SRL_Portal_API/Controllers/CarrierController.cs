using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using SRL.Data_Access.Entity;

namespace SRL_Portal_API.Controllers
{
    public class CarrierController : BaseController
    {
        [AcceptVerbs("GET")]
        [HttpGet]
        public IList<API_LIST_LOAD_CARRIER_Result> Index()
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "carrier\\get"));

            BACKUP_SRL_20180613Entities dbEntities = new BACKUP_SRL_20180613Entities();

            var result = dbEntities.API_LIST_LOAD_CARRIER()
                .ToList<API_LIST_LOAD_CARRIER_Result>();

            return result;
        }
    }
}