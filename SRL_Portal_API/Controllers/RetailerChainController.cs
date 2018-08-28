using System.Collections.Generic;
using System.Web.Http;
using SRL.Data_Access.Repository;
using SRL.Models.Constants;
using SRL.Models.RetailerChain;
using SRL_Portal_API.Common;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// Controller to fetch Retailer Chains list
    /// </summary>
    public class RetailerChainController : BaseController
    {
        [Route("RetailerChains")]
        [HttpGet]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
        public List<RetailerChain> GetRetailerChains()
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"retailerChain\\RetailerChains"));
            RetailerChainRepository retailerChainRepository = new RetailerChainRepository();
            return retailerChainRepository.GetRetailerChains(RequestContext.Principal.Identity.Name);
        }
    }
}