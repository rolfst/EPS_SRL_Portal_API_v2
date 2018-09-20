using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class SSCCPalletCountingModel
    {
        public string CountingType { get; set; }
        public string LoadCarrierName { get; set; }
        public decimal? LoadCarrierEAN { get; set; }
        public Nullable<decimal> ReturnedValue { get; set; }
        //public Nullable<decimal> ExpectedValueMin { get; set; }
        //public Nullable<decimal> ExpectedValueMax { get; set; }
        public string ExpectedValueMinMax { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Deviation { get; set; }
        public decimal Esoft_Packing_Id { get; set; }
        public string ContainerName { get; set; }
        public int CustomerCountingQty { get; set; }
        public int CICountingQty { get; set; }
        public int ReallocationQty { get; set; }
    }
}
