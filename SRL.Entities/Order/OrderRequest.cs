using System;

namespace SRL.Models.Order
{
    public class OrderRequest
    {
        public string OrdOrderNumber { get; set; }
        public int RetailerChainId { get; set; }
        public DateTime? OrderDateFrom { get; set; }
        public DateTime? OrderDateTo { get; set; }
        public bool OrderNew { get; set; }
        public bool OrderOpen { get; set; }
        public bool OrderValidated { get; set; }
        public DateTime? CiDateFrom { get; set; }
        public DateTime? CiDateTo { get; set; }
        public DateTime? ValidationDeadline { get; set; }
        public string User { get; set; }
        public string ActorIdFrom { get; set; }
        public string ActorIdTo { get; set; }
        public string OrderNumber { get; set; }
        public bool ShopCountOk { get; set; }
        public bool ShopCountNok { get; set; }
        public bool ValidationOpen { get; set; }
        public bool ValidationExceeded { get; set; }
        public bool ValidationPassed { get; set; }

        public OrderRequest(string ordOrderNumber = null, int retailerChainId = -1, DateTime? orderDateFrom = null, DateTime? orderDateTo = null, bool orderNew = false, bool orderOpen = false, bool orderValidated = false, DateTime? ciDateFrom = null, DateTime? ciDateTo = null, DateTime? validationDeadline = null, string user = null, string actorIdFrom = null, string actorIdTo = null, string orderNumber = null, bool shopCountOk = false, bool shopCountNok = false, bool validationOpen = false, bool validationExceeded = false, bool validationPassed = false)
        {
            OrdOrderNumber = ordOrderNumber;
            RetailerChainId = retailerChainId;
            OrderDateFrom = orderDateFrom;
            OrderDateTo = orderDateTo;
            OrderNew = orderNew;
            OrderOpen = orderOpen;
            OrderValidated = orderValidated;
            CiDateFrom = ciDateFrom;
            CiDateTo = ciDateTo;
            ValidationDeadline = validationDeadline;
            User = user;
            ActorIdFrom = actorIdFrom;
            ActorIdTo = actorIdTo;
            OrderNumber = orderNumber;
            ShopCountOk = shopCountOk;
            ShopCountNok = shopCountNok;
            ValidationOpen = validationOpen;
            ValidationExceeded = validationExceeded;
            ValidationPassed = validationPassed;
        }
    }
}
