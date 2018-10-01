using System;

namespace SRL.Models.Order
{
    public class OrderResponse
    {
        public decimal OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string ActorFrom { get; set; }
        public string ActorTo { get; set; }
        public string OrderStatus { get; set; }
        public double ValidationDeadline { get; set; }
        public bool CountingOK { get; set; }
        public DateTime? CIDate { get; set; }
        public bool IsValidated { get; set; }
        public string ValidationStatus { get; set; }
        public string ShipmentNumber { get; set; }
    }
}
