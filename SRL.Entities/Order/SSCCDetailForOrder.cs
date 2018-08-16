using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.Order
{
    public class SSCCDetailForOrder
    {
        public string SSCC { get; set; }
        public string SSCCStatus { get; set; }
        public List<RTIQty> RTIQuatities { get; set; }
        public int TotalCounting { get; set; }
        public string LoadCarrierName { get; set; }
        public string Unit { get; set; }
        public decimal ReturnedValue { get; set; }
        public string ExpectedValue { get; set; }
        public decimal ExpectedValueMin { get; set; }
        public decimal ExpectedValueMax { get; set; }
        public string ActorOrigin { get; set; }
        public decimal Deviation { get; set; }
    }
}
