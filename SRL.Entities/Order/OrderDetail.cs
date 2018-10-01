using System;
using SRL.Models.Enums;

namespace SRL.Models.Order
{
    public class OrderDetail
    {
        public string OrderNumber { get; set; }
        public decimal OrderId { get; set; }
        public string FromActorName { get; set; }
        public string FromActorAddressLine1 { get; set; }
        public string FromActorAddressLine2 { get; set; }
        public string ToActorName { get; set; }
        public string ToActorAddressLine1 { get; set; }
        public string ToActorAddressLine2 { get; set; }
        public string Status { get; set; }
        public DateTime? FirstReceiptDate { get; set; }
        public DateTime? CIDate { get; set; }
        public decimal? OutBound { get; set; }
        public decimal? InBound { get; set; }
        public int? CI { get; set; }
        public int? ValidationDeadline { get; set; }
        public decimal? TotalSSCCs { get; set; }
        public int OpenSSCCs { get; set; }
        public int ApprovedSSCCs { get; set; }
        public decimal ToApprovedPercentage { get; set; }
    }
}
