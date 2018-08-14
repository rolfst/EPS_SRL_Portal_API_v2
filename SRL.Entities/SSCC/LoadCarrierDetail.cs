using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class LoadCarrierDetail
    {
        public string CountingType { get; set; }
        public Nullable<decimal> ReturnedValue { get; set; }
        public string ExpectedValueMinMax { get; set; }

        public decimal ExpectedValueMin { get; set; }
        public decimal ExpectedValuemax { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Deviation { get; set; }
        public string Actor { get; set; }
        public int ActorId { get; set; }
        public string LoadCarrierName { get; set; }
        public decimal? LoadCarrierEAN { get; set; }
    }
}
