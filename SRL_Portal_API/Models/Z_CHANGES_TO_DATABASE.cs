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
    
    public partial class Z_CHANGES_TO_DATABASE
    {
        public long Z_CHANGES_TO_DATABASE_ID { get; set; }
        public string SSCC { get; set; }
        public Nullable<decimal> ORDER_NUMBER { get; set; }
        public Nullable<decimal> NEW_ORDER_NUMBER { get; set; }
        public Nullable<decimal> OLD_ACTOR { get; set; }
        public Nullable<decimal> NEW_ACTOR { get; set; }
        public int LOAD_MESSAGE_STATUS_ID { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public string OLD_LOAD_UNIT_CONDITION_CODE { get; set; }
        public string NEW_LOAD_UNIT_CONDITION_CODE { get; set; }
        public Nullable<int> OLD_QTY_RTI { get; set; }
        public Nullable<decimal> ESOFT_PACKING_ID { get; set; }
        public Nullable<int> NEW_QTY_RTI { get; set; }
        public string DELETE_SSCC { get; set; }
        public string OLD_SSCC { get; set; }
        public string NEW_SSCC { get; set; }
        public long TRA_ITEM_IN_ID { get; set; }
        public string SLA_CODE { get; set; }
        public string TIME { get; set; }
        public string VALIDATION { get; set; }
        public string OLD_LOAD_UNIT_CONDITION_SUB_CODE { get; set; }
        public string NEW_LOAD_UNIT_CONDITION_SUB_CODE { get; set; }
        public string OLD_LOAD_CARRIER_EAN { get; set; }
        public string NEW_LOAD_CARRIER_EAN { get; set; }
        public string VOID_SSCC { get; set; }
    }
}
