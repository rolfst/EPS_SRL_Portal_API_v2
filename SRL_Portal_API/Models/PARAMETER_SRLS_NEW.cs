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
    
    public partial class PARAMETER_SRLS_NEW
    {
        public int PARAMETER_ID { get; set; }
        public string PAR_CODE { get; set; }
        public string PAR_NAME { get; set; }
        public string PAR_VALUE { get; set; }
        public string PAR_REFERENCE { get; set; }
        public string PAR_ACTIVE_YN { get; set; }
        public string INSERT_USER { get; set; }
        public Nullable<System.DateTime> INSERT_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string DESTINATION { get; set; }
    }
}