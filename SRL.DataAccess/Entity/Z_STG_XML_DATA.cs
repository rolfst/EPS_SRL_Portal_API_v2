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
    
    public partial class Z_STG_XML_DATA
    {
        public int Z_STG_XML_DATA_ID { get; set; }
        public string XMLNAME { get; set; }
        public string XMLDATA { get; set; }
        public Nullable<System.DateTime> DATETIME_IMPORTED { get; set; }
        public Nullable<System.DateTime> DATETIME_PROCESSED { get; set; }
        public Nullable<bool> IS_PROCESSED { get; set; }
        public Nullable<int> Z_STG_XML_STATUS_ID { get; set; }
        public Nullable<long> TRA_ITEM_IN_ID { get; set; }
    }
}
