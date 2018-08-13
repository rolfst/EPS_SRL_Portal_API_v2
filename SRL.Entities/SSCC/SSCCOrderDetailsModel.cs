using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class SSCCOrderDetailsModel
    {
        public string SsccNumber { get; set; }
        public string OrderNumber { get; set; }
        public string PhysicalFrom { get; set; }
        public string PhysicalTo { get; set; }
        public string TransportedBy { get; set; }
        public int AnomaliesCount { get; set; }
        public double ValidationDeadline { get; set; }
        public bool Validated { get; set; }
        public string SsccStatus { get; set; }

    }
}
