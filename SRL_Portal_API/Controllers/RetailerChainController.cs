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
            List<RetailerChain> retailerChains =  retailerChainRepository.GetRetailerChains();
            //Check whether logged in user is external
            string userEmail = RequestContext.Principal.Identity.Name;

            UserRespository userRespository = new UserRespository();
            if (userRespository.IsExternalUser(userEmail))
            {
                List<RetailerChain> retailerChainsForUser = new List<RetailerChain>();
              List<int?> retailerChainIds = userRespository.GetRetailerChainIdList(userEmail);
                if (retailerChainIds.Any())
                {
                    foreach (var retailerChainId in retailerChainIds)
                    {
                        if (retailerChainId != null)
                            retailerChainsForUser.Add(retailerChains.Where(r => r.RetailerChainId == retailerChainId).FirstOrDefault());
                    }
                }
                return retailerChainsForUser;
            }
            else
                return retailerChains;
        }
    }
}