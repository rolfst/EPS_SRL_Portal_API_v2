//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRL_Portal_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class REF_ORDER
    {
        public decimal ID_ORDER { get; set; }
        public string ORD_ORDER_NUMBER { get; set; }
        public string ORD_CUSTOMER_REFERENCE { get; set; }
        public System.DateTime ORD_DATE { get; set; }
        public decimal ORDER_STATUS_ID { get; set; }
        public decimal ACTOR_ID_FROM { get; set; }
        public decimal ACTOR_ID_FROM_CONFIRMED { get; set; }
        public decimal ACTOR_ID_TO { get; set; }
        public decimal ACTOR_ID_TO_CONFIRMED { get; set; }
        public Nullable<decimal> ACTOR_ID_TRANSPORTER { get; set; }
        public string ORD_FROM_ADDRESS_LINE1 { get; set; }
        public string ORD_FROM_HOUSE_NB { get; set; }
        public string ORD_FROM_ADDITIONAL_NB { get; set; }
        public string ORD_FROM_POSTAL_CODE { get; set; }
        public string ORD_FROM_DOMICILE { get; set; }
        public decimal COUNTRY_ID_FROM { get; set; }
        public string ORD_TO_ADDRESS_LINE1 { get; set; }
        public string ORD_TO_HOUSE_NB { get; set; }
        public string ORD_TO_ADDITIONAL_NB { get; set; }
        public string ORD_TO_POSTAL_CODE { get; set; }
        public string ORD_TO_DOMICILE { get; set; }
        public decimal COUNTRY_ID_TO { get; set; }
        public string ORD_NUMBER_PLATE { get; set; }
        public string TRA_REFERENCE { get; set; }
        public Nullable<decimal> ACTOR_ID_PARTNER { get; set; }
        public Nullable<decimal> TRANSACTION_TYPE_ID { get; set; }
        public Nullable<decimal> BASIC_TRANSACTION_TYPE_ID { get; set; }
        public Nullable<decimal> TEMP_RECEIPT_DATE { get; set; }
        public Nullable<decimal> NUMBER_OF_PPC { get; set; }
        public Nullable<decimal> RECEIPT_STATUS_ID { get; set; }
        public Nullable<decimal> TRA_DATE_DEFINITIVE { get; set; }
        public Nullable<System.DateTime> INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public Nullable<decimal> NUMBER_OF_PACKING { get; set; }
    }
}
