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
    
    public partial class SSCC_MANAGEMENT
    {
        public long SSCC_MANAGEMENT_ID { get; set; }
        public string SSCC { get; set; }
        public System.DateTime SSCC_BEGIN_DATE { get; set; }
        public Nullable<System.DateTime> SSCC_END_DATE { get; set; }
        public string SSCC_MANAGEMENT_STATUS { get; set; }
        public Nullable<long> SSCC_ORDER_ID { get; set; }
        public System.DateTime INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public System.DateTime UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
    
        public virtual SSCC_ORDER SSCC_ORDER { get; set; }
    }
}
