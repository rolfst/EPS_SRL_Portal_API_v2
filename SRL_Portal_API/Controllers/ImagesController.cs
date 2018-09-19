using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Repository;
using SRL.Models.SSCC;

namespace SRL_Portal_API.Controllers
{
    [RoutePrefix("api")]
    public class ImagesController : BaseController
    {
        private readonly SSCCImagesRepository _repo = new SSCCImagesRepository();

        [HttpGet]
        public async Task<IEnumerable<SSCCImagesModel>> GetSsccImages([FromUri]string sscc)
        {
            // Fill the list of SSCCDetailsImagesModels
            var imageList = _repo.GetSSCCImages(sscc);

            var imageResult = new List<SSCCImagesModel>();

            Parallel.ForEach(imageList, (item) =>
            {
                imageResult.Add(GetImage(item));
            });
            return imageResult;
        }

        private static SSCCImagesModel GetImage(API_LCP_IMAGES_Result item)
        {
            return new SSCCImagesModel
            {
                EncodedImage = ConvertImageToEncodedString(item.PICTURE_EVIDENCE_PATH).Result,
                PicturePosition = item.PICTURE_POSITION,
                PalletPosition = item.PALLET_POSITION
            };
        }
        private static async Task<string> ConvertImageToEncodedString(string itemPictureEvidencePath)
        {
            // todo: Get file from SFTP server.

            if (!File.Exists(itemPictureEvidencePath))
            {
                itemPictureEvidencePath = "C:/pic/sscc.png";
            }

            // Grab image from local directory if requested file doesn't exist.
            if (!File.Exists(itemPictureEvidencePath)) return "INVALID";

            using (var stream = File.OpenRead(itemPictureEvidencePath))
            {
                var fileBytes = new byte[stream.Length];
                await stream.ReadAsync(fileBytes, 0, Convert.ToInt32(stream.Length));
                return Convert.ToBase64String(fileBytes);
            }
        }
    }
}