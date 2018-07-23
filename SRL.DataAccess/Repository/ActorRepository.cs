using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRL.Data_Access.Entity;

namespace SRL.Data_Access.Repository
{
    public class ActorRepository
    {
        public IEnumerable<API_LIST_ACTORS_TRANSACTION_Result> GetActorList(int retailerChainId)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                IEnumerable<API_LIST_ACTORS_TRANSACTION_Result> result = dbEntity.API_LIST_ACTORS_TRANSACTION(retailerChainId);
                return result;
            }
        }
    }
}
