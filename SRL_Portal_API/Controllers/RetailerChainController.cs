using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SRL.Data_Access.Repository;
using SRL.Models.RetailerChain;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// Controller to fetch Retailer Chains list
    /// </summary>
    public class RetailerChainController : BaseController
    {
        [Route("RetailerChains")]
        [HttpGet]
        public List<RetailerChain> GetRetailerChains()
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"retailerChain\\RetailerChains"));
            RetailerChainRepository retailerChainRepository = new RetailerChainRepository();
            return retailerChainRepository.GetRetailerChains(RequestContext.Principal.Identity.Name);
        }
    }
}