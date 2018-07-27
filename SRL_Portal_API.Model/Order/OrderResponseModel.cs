using System;

namespace SRL_Portal_API.Model.FilterOrder
{
    public class OrderResponseModel
    {
        public object OrderId { get; set; }
        public object OrderDate { get; set; }
        public object OrderNumber { get; set; }
        public object ActorFrom { get; set; }
        public object ActorTo { get; set; }
        public object OrderStatus { get; set; }
        public object ValidationDeadline { get; set; }
        public object SlaOK { get; set; }
        public object CountingOK { get; set; }
        public object CIDate { get; set; }
        public object IsValidated { get; set; }
        public object ValidationStatus { get; set; }
    }
}
