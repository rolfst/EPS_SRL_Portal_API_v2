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
    
    public partial class RETAILER_CHAIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RETAILER_CHAIN()
        {
            this.ACTOR_REFERENCE = new HashSet<ACTOR_REFERENCE>();
            this.DEVIATION_BY_RETAILER = new HashSet<DEVIATION_BY_RETAILER>();
            this.STANDARD_DISTRIBUTION = new HashSet<STANDARD_DISTRIBUTION>();
        }
    
        public int RETAILER_CHAIN_ID { get; set; }
        public string RETAILER_CHAIN_CODE { get; set; }
        public string RETAILER_CHAIN1 { get; set; }
        public string FINANCIAL_PARTNER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTOR_REFERENCE> ACTOR_REFERENCE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEVIATION_BY_RETAILER> DEVIATION_BY_RETAILER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STANDARD_DISTRIBUTION> STANDARD_DISTRIBUTION { get; set; }
    }
}
