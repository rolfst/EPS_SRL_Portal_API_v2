using SRL.Data_Access.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRL.Data_Access.Repository
{
    public class SSCCOrderDetailsRepository
    {
        public API_LCP_ORDER_DETAILS_Result GetSSCCOrderDetails(string id)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                var orderDetails = dbEntity.API_LCP_ORDER_DETAILS(id).FirstOrDefault();

                return orderDetails;
            }
        }
    }
}
