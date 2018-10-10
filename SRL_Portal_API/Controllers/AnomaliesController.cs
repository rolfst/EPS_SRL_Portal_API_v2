using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Repository;
using SRL.Models.Constants;
using SRL_Portal_API.Common;

namespace SRL_Portal_API.Controllers
{
    public class AnomaliesController : BaseController
    {
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

            var result = repo.GetAnomalies(retailerChainId).ToList();
            foreach (var anomaly in result)
            {
                var label = anomaly.LOAD_UNIT_CONDITION_LABEL;
                label = label.Substring(label.IndexOf('-') + 1).Trim();
                anomaly.LOAD_UNIT_CONDITION_LABEL = label;
            }

            return result;
        }
    }
}