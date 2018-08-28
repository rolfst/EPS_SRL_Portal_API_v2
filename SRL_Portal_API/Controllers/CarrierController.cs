using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SRL.Data_Access.Entity;
using SRL.Models.Constants;
using SRL_Portal_API.Common;

namespace SRL_Portal_API.Controllers
{
    public class CarrierController : BaseController
    {
        [AcceptVerbs("GET")]
        [HttpGet]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
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