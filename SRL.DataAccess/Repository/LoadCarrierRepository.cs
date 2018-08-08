using SRL.Data_Access.Entity;
using SRL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SRL.Data_Access.Repository
{
    class LoadCarrierRepository
    {
        public IEnumerable<API_LIST_LOAD_CARRIER_Result> GetCarriersList()
        {
                using (var dbEntity = new BACKUP_SRL_20180613Entities())
                {
                    dbEntity.Configuration.ProxyCreationEnabled = false;

                    IEnumerable<API_LIST_LOAD_CARRIER_Result> result = dbEntity.API_LIST_LOAD_CARRIER();

                    return result;
                };
        }
    }
}
