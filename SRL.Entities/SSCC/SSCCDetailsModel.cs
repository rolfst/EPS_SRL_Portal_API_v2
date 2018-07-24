using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class SSCCDetailsModel
    {
        public SSCCOrderDetailsModel OrderDetails { get; set; }
        public List<SSCCLoadCarrierModel> LoadCarrierList { get; set; }
        public List<SSCCPalletCountingModel> PalletCountingList { get; set; }
        public List<SSCCImagesModel> ImageList { get; set; }
        public SSCCDeviationsModel DeviationDetailsList { get; set; }
    }
}
