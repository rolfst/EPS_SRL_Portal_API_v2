using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Entity;

namespace SRL.Data_Access.Repository
{
    public class SSCCPalletCountingRepository
    {
        public IEnumerable<API_LCP_COUNTING_Result> GetSSCCPalletCounting(string id)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                var palletCountingList = dbEntity.API_LCP_COUNTING(id).ToList<API_LCP_COUNTING_Result>();

                return palletCountingList;
            }
        }
    }
}
