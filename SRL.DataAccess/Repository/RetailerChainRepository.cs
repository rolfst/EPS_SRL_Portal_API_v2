using SRL.Models.RetailerChain;
using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Adapter;

namespace SRL.Data_Access.Repository
{
    /// <summary>
    /// Retailer chain repository to fetch its list from database
    /// </summary>
    public class RetailerChainRepository
    {
        public List<RetailerChain> GetRetailerChains()
        {
            List<RetailerChain> retailerChains = new List<RetailerChain>();
            using (var cntx = new SRL.Data_Access.Entity.BACKUP_SRL_20180613Entities())
            {
                retailerChains = cntx.API_LIST_RETAILERS().ToList().ToEntityRetailerChainList();
            }
            return retailerChains;
        }
    }
}
