using System.Collections.Generic;

namespace SRL.Models
{
    public class SendReportRequest
    {
        public int ActorId { get; set; }
        public int RetailerChainId { get; set; }
        public int OrderNumber { get; set; }
    }

    public class SendReportRequestList
    {
        public List<SendReportRequest> Requests { get; set; }
    }
}
