using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRL.Data_Access.Entity;

namespace SRL.Data_Access.Repository
{
    public class SSCCLoadCarrierRepository
    {
        public IEnumerable<API_SSCC_LOADCARRIER_DETAILS_Result> GetSSCCLoadCarrier(string id)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                var loadCarrierDetailsList = dbEntity.API_SSCC_LOADCARRIER_DETAILS(id).ToList<API_SSCC_LOADCARRIER_DETAILS_Result>();

                return loadCarrierDetailsList;
            }
        }
    }
}
