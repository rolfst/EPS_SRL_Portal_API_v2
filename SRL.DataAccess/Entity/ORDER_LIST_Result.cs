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
    
    public partial class ORDER_LIST_Result
    {
        public string ORD_ORDER_NUMBER { get; set; }
        public decimal ID_ORDER { get; set; }
        public string REGISTERED_BY { get; set; }
        public decimal FROM_CODE { get; set; }
        public string FROM_NAME { get; set; }
        public string FROM_ADDRESSLINE1 { get; set; }
        public string FROM_ADDRESSLINE2 { get; set; }
        public decimal TO_CODE { get; set; }
        public string TO_NAME { get; set; }
        public string TO_ADDRESSLINE1 { get; set; }
        public string TO_ADDRESSLINE2 { get; set; }
        public System.DateTime ORDER_DATE { get; set; }
        public decimal ORDER_STATUS { get; set; }
        public Nullable<System.DateTime> UNLOADING_DATE { get; set; }
        public Nullable<System.DateTime> CI_DATE { get; set; }
        public string ORD_CUSTOMER_REFERENCE { get; set; }
        public string SHIPMENT_COMPANY { get; set; }
        public string SHIPMENT_COMPANY_NAME { get; set; }
        public string TOUR_NUMBER { get; set; }
        public string LICENSE_PLATE { get; set; }
        public Nullable<decimal> OUTBOUND_SSCC_ON_ORDER { get; set; }
        public Nullable<int> INBOUND_SSCC_ON_ORDER { get; set; }
        public Nullable<int> CI_SSCC_ON_ORDER { get; set; }
        public Nullable<int> NUMBER_SSCC_ON_ORDER_OPEN { get; set; }
        public Nullable<int> NUMBER_SSCC_ON_ORDER_VALIDATED { get; set; }
        public int SHOP_OK { get; set; }
        public int SHOP_NOK { get; set; }
        public Nullable<System.DateTime> VALIDATION_DEADLINE { get; set; }
        public Nullable<int> VALIDATED { get; set; }
        public Nullable<System.DateTime> VALIDATED_DATE { get; set; }
        public int RETAILER_CHAIN_ID { get; set; }
    }
}
