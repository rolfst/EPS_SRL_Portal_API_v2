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
    
    public partial class TRANSACTION_SSCC_RTI_DETAILS_QTY_DIF
    {
        public string SSCC { get; set; }
        public Nullable<decimal> FIRST_SSCC_USAGE { get; set; }
        public Nullable<int> QTY_DIF { get; set; }
        public Nullable<decimal> QTY_SEU_EQUIVALENT { get; set; }
        public Nullable<long> TRA_ITEM_IN_ID { get; set; }
        public Nullable<long> MOD3 { get; set; }
        public bool REPROCESSED { get; set; }
        public int TRANSACTION_SSCC_RTI_DETAILS_QTY_DIF_ID { get; set; }
    }
}
