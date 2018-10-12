using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Entity;

namespace SRL.Data_Access.Repository
{
    public class SSCCImagesRepository
    {
        public IEnumerable<API_LCP_IMAGES_Result> GetSSCCImages(string id, bool isExternal = false)
        {
            IEnumerable<API_LCP_IMAGES_Result> imageList;
            string imageType = isExternal ? Resources.Common.External : Resources.Common.Internal;
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                if (isExternal)
                    imageList = dbEntity.API_LCP_IMAGES(id).ToList<API_LCP_IMAGES_Result>().Where(i => i.PURPOSE == imageType);
                else
                    imageList = dbEntity.API_LCP_IMAGES(id).ToList<API_LCP_IMAGES_Result>();

                return imageList;
            }
        }
    }
}
