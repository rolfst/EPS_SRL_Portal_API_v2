using System;

namespace SRL_Portal_API.Model.FilterOrder
{
    public class FilterOrderResponseModel
    {
        public object OrderId { get; set; }
        public object OrderDate { get; set; }
        public object OrderNumber { get; set; }
        public object From { get; set; }
        public object To { get; set; }
        public object OrderStatus { get; set; }
        public object ValidationDeadline { get; set; }
        public object SlaOk { get; set; }
        public object CountingOk { get; set; }
        public object CiDate { get; set; }
    }
}
