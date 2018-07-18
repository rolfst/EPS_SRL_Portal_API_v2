using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRL.Data_Access.Entity;

namespace SRL.Data_Access.Repository
{
    public class SSCCPalletCountingRepository
    {
        public IEnumerable<API_SSCC_PALLET_COUNTING_Result> GetSSCCPalletCounting(string id)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                var palletCountingList = dbEntity.API_SSCC_PALLET_COUNTING(id).ToList<API_SSCC_PALLET_COUNTING_Result>();

                return palletCountingList;
            }
        }
    }
}
