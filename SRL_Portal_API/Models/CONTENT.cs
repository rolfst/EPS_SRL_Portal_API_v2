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
    
    public partial class CONTENT
    {
        public long CONTENT_ID { get; set; }
        public Nullable<long> TRA_ITEM_IN_ID { get; set; }
        public string EAN { get; set; }
        public string GPC { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<bool> GOODSCRAPPING { get; set; }
        public Nullable<System.DateTime> INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public Nullable<decimal> QTY_RTG { get; set; }
        public string UNIT { get; set; }
        public string SSCC { get; set; }
    }
}
