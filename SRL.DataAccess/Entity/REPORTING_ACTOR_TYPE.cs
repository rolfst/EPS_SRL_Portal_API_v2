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
    
    public partial class REPORTING_ACTOR_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REPORTING_ACTOR_TYPE()
        {
            this.ACTOR_REFERENCE = new HashSet<ACTOR_REFERENCE>();
        }
    
        public int REPORTING_ACTOR_TYPE_ID { get; set; }
        public string REPORTING_ACTOR_TYPE_CODE { get; set; }
        public string REPORTING_ACTOR_TYPE_NAME { get; set; }
        public int REPORTING_ACTOR_TYPE_SORT { get; set; }
        public System.DateTime INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public System.DateTime UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTOR_REFERENCE> ACTOR_REFERENCE { get; set; }
    }
}
