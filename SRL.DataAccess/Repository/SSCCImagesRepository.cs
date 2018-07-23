using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRL.Data_Access.Entity;

namespace SRL.Data_Access.Repository
{
    public class SSCCImagesRepository
    {
        public IEnumerable<API_SSCC_IMAGES_Result> GetSSCCImages(string id)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                var imageList = dbEntity.API_SSCC_IMAGES(id).ToList<API_SSCC_IMAGES_Result>();

                return imageList;
            }
        }
    }
}
