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
    
    public partial class SORTING_STATUS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SORTING_STATUS()
        {
            this.LOAD_UNIT = new HashSet<LOAD_UNIT>();
            this.SORTING_STATUS_TRANSLATION = new HashSet<SORTING_STATUS_TRANSLATION>();
        }
    
        public int SORTING_STATUS_ID { get; set; }
        public string SORTING_STATUS_CODE { get; set; }
        public int SORTING_STATUS_SORT { get; set; }
        public Nullable<int> SSCC_POSTITION { get; set; }
        public System.DateTime INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public System.DateTime UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOAD_UNIT> LOAD_UNIT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SORTING_STATUS_TRANSLATION> SORTING_STATUS_TRANSLATION { get; set; }
    }
}
