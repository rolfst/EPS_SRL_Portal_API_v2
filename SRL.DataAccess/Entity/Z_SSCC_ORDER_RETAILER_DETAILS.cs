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
    
    public partial class Z_SSCC_ORDER_RETAILER_DETAILS
    {
        public string actor { get; set; }
        public int RETAILER_CHAIN_ID { get; set; }
        public string RETAILER_CHAIN_CODE { get; set; }
        public System.DateTime ORDER_DATE { get; set; }
        public string MAX_SSCC_ISSUED { get; set; }
        public long MAX_SSCC_ISSUED_NUMBER { get; set; }
        public string FIRST_SSCC_IN_TRANSACTION { get; set; }
        public long SSCC_Quantity_Occupied { get; set; }
    }
}
