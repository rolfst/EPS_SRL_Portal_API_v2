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
    
    public partial class TRANSACTION_SSCC_RTI_DETAILS_DEL
    {
        public long TRANSACTION_SSCC_RTI_DETAILS_ID { get; set; }
        public long TRANSACTION_ID { get; set; }
        public long SSCC_RTI_DETAILS_ID { get; set; }
        public int RTI_ID { get; set; }
        public string SSCC { get; set; }
        public Nullable<decimal> ESOFT_PACKING_ID { get; set; }
        public int QTY_RTI { get; set; }
        public decimal SEU_RECALCULATED { get; set; }
        public Nullable<int> LOAD_MESSAGE_STATUS_ID { get; set; }
        public System.DateTime INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public System.DateTime UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public string REALLOCATION_NEEDED { get; set; }
        public string UNIT { get; set; }
        public string AUDIT_USER { get; set; }
        public System.DateTime AUDIT_TIMESTAMP { get; set; }
    }
}
