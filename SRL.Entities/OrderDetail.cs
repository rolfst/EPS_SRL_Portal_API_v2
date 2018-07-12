using System;
using System.Collections.Generic;
using System.Text;
using SRL.Entities.Enums;
namespace SRL.Entities
{
    public class OrderDetail
    {
        public string OrderNumber { get; set; }
        public string FromActorName { get; set; }
        public string FromActorAddressLine1 { get; set; }
        public string FromActorAddressLine2 { get; set; }
        public string ToActorName { get; set; }
        public string ToActorAddressLine1 { get; set; }
        public string ToActorAddressLine2 { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? UnloadingDate { get; set; }
        public string Transport { get; set; }
        public DateTime? CIDate { get; set; }
        public string ShipmentNumber { get; set; }
        public string Reference { get; set; }
        public string Transporter { get; set; }
        public string LicensePlate { get; set; }
        public decimal? TotalSSCCs { get; set; }
        public int OpenSSCCs { get; set; }
        public int ApprovedSSCCs { get; set; }
public decimal ToApprovedPercentage { get; set; }
    }
}
