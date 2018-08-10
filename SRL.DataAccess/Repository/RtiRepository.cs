using SRL.Data_Access.Entity;
using SRL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SRL.Data_Access.Repository
{
    public class RtiRepository
    {
        public IEnumerable<API_LIST_RTI_Result> GetRtiList()
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;

                IEnumerable<API_LIST_RTI_Result> result = dbEntity.API_LIST_RTI();

                return result;
            };
        }
    }
}
