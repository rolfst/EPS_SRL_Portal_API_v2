//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRL.Data_Access.Entity
{
    using System;
    
    public partial class API_SSCC_OVERVIEW_Result
    {
        public Nullable<decimal> ORDER_NUMBER { get; set; }
        public long SSCC_ID { get; set; }
        public string SSCC { get; set; }
        public Nullable<System.DateTime> CI_DATETIME { get; set; }
        public Nullable<System.DateTime> FIRST_SSCC_USAGE { get; set; }
        public Nullable<int> ACTOR_ID { get; set; }
        public int ACTOR_ORIGIN_ID { get; set; }
        public int SSCC_STATUS { get; set; }
        public Nullable<decimal> SLA_VALUE { get; set; }
        public Nullable<decimal> SLA_MIN_VALUE { get; set; }
        public Nullable<decimal> SLA_MAX_VALUE { get; set; }
        public Nullable<int> SHOP_COUNT { get; set; }
        public Nullable<int> CI_COUNT { get; set; }
        public Nullable<System.DateTime> VALIDATION_DEADLINE { get; set; }
        public bool VALIDATED { get; set; }
        public Nullable<System.DateTime> DATE_VALIDATED { get; set; }
        public System.DateTime FIRST_RECEIPT_DATE { get; set; }
        public string SHIPMENT_NUMBER { get; set; }
    }
}
