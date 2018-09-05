using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Entity;

namespace SRL.Data_Access.Repository
{
    public class AnomalyRepository
    {
        public IEnumerable<API_LIST_LOAD_UNIT_CONDITIONS_Result> GetAnomalies(int? retailerChainId = null)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                return dbEntity.API_LIST_LOAD_UNIT_CONDITIONS(retailerChainId).ToList();
            }
        }
    }
}
