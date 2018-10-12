using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class SSCCImagesModel
    {
        public string ImageUrl { get; set; }
        public string PicturePosition { get; set; }
        public string PalletPosition { get; set; }
        public string TransactionSubType { get; set; }
        public bool IsExternal { get; set; }
    }
}
