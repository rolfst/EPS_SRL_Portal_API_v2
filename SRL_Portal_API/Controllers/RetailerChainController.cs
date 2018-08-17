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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RetailerChainController : ApiController
    {
        [Route("RetailerChains")]
        [HttpGet]
        public List<RetailerChain> GetRetailerChains()
        {
            RetailerChainRepository retailerChainRepository = new RetailerChainRepository();
            return retailerChainRepository.GetRetailerChains(RequestContext.Principal.Identity.Name);
        }
    }
}