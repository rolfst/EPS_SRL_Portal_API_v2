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
    
    public partial class STANDARD_DISTRIBUTION
    {
        public int STANDARD_DISTRIBUTION_ID { get; set; }
        public int RETAILER_CHAIN_ID { get; set; }
        public decimal QTY_SEU_EQUIVALENT { get; set; }
        public int RTI_ID { get; set; }
        public decimal PERCENTAGE { get; set; }
    
        public virtual RETAILER_CHAIN RETAILER_CHAIN { get; set; }
    }
}
