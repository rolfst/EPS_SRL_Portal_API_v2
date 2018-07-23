using SRL.Data_Access.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRL.Data_Access.Repository
{
    public class SSCCDeviationDetailsRepository
    {
        public IEnumerable<API_SSCC_DEVIATION_DETAILS_Result> GetSSCCDeviationDetails(string id)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                var deviationDetailsList = dbEntity.API_SSCC_DEVIATION_DETAILS(id).ToList<API_SSCC_DEVIATION_DETAILS_Result>();

                return deviationDetailsList;
            }
        }
    }
}
