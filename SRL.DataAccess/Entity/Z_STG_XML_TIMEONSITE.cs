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
    
    public partial class Z_STG_XML_TIMEONSITE
    {
        public long Z_STG_XML_TIMEONSITE_ID { get; set; }
        public Nullable<long> TRA_ITEM_IN_ID { get; set; }
        public string TRAILER_NUMBER { get; set; }
        public string BADGE_NUMBER { get; set; }
        public string TOUR_NUMBER { get; set; }
        public Nullable<System.DateTime> DOCK_ARRIVAL { get; set; }
        public Nullable<System.DateTime> LAST_SCAN { get; set; }
        public string LICENSE_PLATE { get; set; }
        public Nullable<System.DateTime> INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public string SSCC { get; set; }
        public Nullable<int> LOAD_MESSAGE_STATUS_ID { get; set; }
    }
}
