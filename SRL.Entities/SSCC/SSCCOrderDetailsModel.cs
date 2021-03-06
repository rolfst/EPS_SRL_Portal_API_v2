using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class SSCCOrderDetailsModel
    {
        public string SsccNumber { get; set; }
        public string OrderNumber { get; set; }
        public decimal? OrderId { get; set; }
        public string PhysicalFrom { get; set; }
        public string PhysicalTo { get; set; }
        public string TransportedBy { get; set; }
        public int AnomaliesCount { get; set; }
        public double ValidationDeadline { get; set; }
        public bool Validated { get; set; }
        public string SsccStatus { get; set; }
        public string ActorOriginName { get; set; }
        public int ActorOriginId { get; set; }
        public string ShipmentNumber { get; set; }

    }
}
