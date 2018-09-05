using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Repository;
using SRL.Models.Constants;
using SRL_Portal_API.Common;

namespace SRL_Portal_API.Controllers
{
    public class AnomalyController : BaseController
    {
        [AcceptVerbs("GET")]
        [HttpGet]
        [CustomAuthorizationFilter(new string[]
        {
            UserRoles.Customer,
            UserRoles.CustomerServiceAgent,
            UserRoles.SuperUser,
            UserRoles.UltraUser,
            UserRoles.WebPortalAdministrator
        })]
        public IEnumerable<API_LIST_LOAD_UNIT_CONDITIONS_Result> GetAnomalies(int? retailerChainId)
        {
            var repo = new AnomalyRepository();

            return repo.GetAnomalies(retailerChainId);
        }
    }
}