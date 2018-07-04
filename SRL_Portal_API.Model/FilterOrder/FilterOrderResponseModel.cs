using System;

namespace SRL_Portal_API.Model.FilterOrder
{
    public class FilterOrderResponseModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string OrderStatus { get; set; }
        public string ValidationDeadline { get; set; }
        public string SlaOk { get; set; }
        public string CountingOk { get; set; }
        public DateTime CiDate { get; set; }
    }
}
