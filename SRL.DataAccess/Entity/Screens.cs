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
    
    public partial class Screens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Screens()
        {
            this.RoleScreen = new HashSet<RoleScreen>();
        }
    
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public bool isActive { get; set; }
        public string RouterLink { get; set; }
        public int Level { get; set; }
        public Nullable<int> ParentScreenId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleScreen> RoleScreen { get; set; }
    }
}
