using System;

namespace SRL_Portal_API.Model.FilterOrder
{
    public class FilterOrderRequestModel
    {
        public int ActorId { get; set; }
        public DateTime OrderDateFrom { get; set; }
        public DateTime OrderDateTo { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CiDateTo { get; set; }
        public DateTime CiDateFrom { get; set; }
        public string ValidationDeadlineStatus { get; set; }
        public string User { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int OrderNumber { get; set; }
        public string ShopOkStatus { get; set; }    
        public string SlaOkStatus { get; set; }
    }
}
