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
    
    public partial class ERROR_HANDLING_ARCHIVE
    {
        public long ERROR_HANDLING_ARCHIVE_ID { get; set; }
        public long ERROR_HANDLING_ID { get; set; }
        public int ERROR_ID { get; set; }
        public string ERROR_HANDLING_MESSAGE { get; set; }
        public string ERROR_HANDLING_STATE { get; set; }
        public string USER_NAME { get; set; }
        public System.DateTime ERROR_DATE { get; set; }
    
        public virtual ERROR ERROR { get; set; }
    }
}
