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
    
    public partial class LOAD_UNIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAD_UNIT()
        {
            this.LOAD_UNIT_SLA = new HashSet<LOAD_UNIT_SLA>();
            this.LOAD_UNIT_TRANSLATION = new HashSet<LOAD_UNIT_TRANSLATION>();
            this.SSCC_ORDER = new HashSet<SSCC_ORDER>();
        }
    
        public int LOAD_UNIT_ID { get; set; }
        public string LOAD_UNIT_CODE { get; set; }
        public int LOAD_UNIT_SORT { get; set; }
        public int LOAD_CARRIER_ID { get; set; }
        public int SORTING_STATUS_ID { get; set; }
        public Nullable<int> STACKING_HEIGHT { get; set; }
        public Nullable<int> NUMBER_STACKS { get; set; }
        public Nullable<int> NUMBER_SEU { get; set; }
        public Nullable<decimal> STANDARD_VOLUME { get; set; }
        public System.DateTime INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public System.DateTime UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public Nullable<decimal> MAX { get; set; }
        public Nullable<decimal> MIN { get; set; }
        public string UNIT { get; set; }
        public string TYPE { get; set; }
        public Nullable<bool> FREE_PALLET { get; set; }
    
        public virtual LOAD_CARRIER LOAD_CARRIER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOAD_UNIT_SLA> LOAD_UNIT_SLA { get; set; }
        public virtual SORTING_STATUS SORTING_STATUS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOAD_UNIT_TRANSLATION> LOAD_UNIT_TRANSLATION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SSCC_ORDER> SSCC_ORDER { get; set; }
    }
}
