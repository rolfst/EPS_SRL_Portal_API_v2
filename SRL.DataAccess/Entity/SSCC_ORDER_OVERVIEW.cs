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
    using System.Collections.Generic;
    
    public partial class SSCC_ORDER_OVERVIEW
    {
        public long SSCC_ORDER_ID { get; set; }
        public string ACTOR_REFERENCE_ID { get; set; }
        public decimal ACTOR_CODE { get; set; }
        public string LABEL_TYPE { get; set; }
        public string REPORTING_ACTOR_TYPE_NAME { get; set; }
        public int QTY_ORDERED { get; set; }
        public string ORDERED_BY { get; set; }
        public System.DateTime ORDER_DATE { get; set; }
        public string FILE_NAME { get; set; }
        public string SPLIT { get; set; }
        public string CARDBOARD_BOX { get; set; }
        public string FIRST_SSCC { get; set; }
        public string LAST_SSCC { get; set; }
        public Nullable<decimal> INVOICE_TO { get; set; }
        public Nullable<decimal> DELIVERY_TO { get; set; }
        public System.DateTime INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public System.DateTime UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
    }
}
