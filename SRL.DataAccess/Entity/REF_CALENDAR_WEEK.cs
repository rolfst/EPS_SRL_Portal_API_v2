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
    
    public partial class REF_CALENDAR_WEEK
    {
        public decimal WEEK_KEY { get; set; }
        public string WEEK_LABEL { get; set; }
        public Nullable<int> WEEK_NR { get; set; }
        public string WEEK_NAME_SHORT { get; set; }
        public string WEEK_NAME { get; set; }
        public Nullable<int> WEEK_vs_CURRENT_WEEK_IN_CALENDAR { get; set; }
        public Nullable<int> WEEK_vs_CURRENT_WEEK_IN_YEAR { get; set; }
        public decimal YEAR_KEY { get; set; }
        public Nullable<int> YEAR_NR { get; set; }
        public string YEAR_LABEL { get; set; }
        public string YEAR_NAME { get; set; }
        public Nullable<int> YEAR_vs_CURRENT_YEAR_IN_CALENDAR { get; set; }
    }
}
