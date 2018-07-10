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
    
    public partial class Z_STG_XML_TRANSACTION
    {
        public long Z_STG_XML_TRANSACTION_ID { get; set; }
        public string SSCC { get; set; }
        public Nullable<System.DateTime> TRANSACTION_DATE { get; set; }
        public string TRANSACTION_TIME { get; set; }
        public string TRANSACTION_TYPE_ID { get; set; }
        public string TRANSACTION_GMT_OFFSET { get; set; }
        public Nullable<int> ACTOR_ID { get; set; }
        public string TRANSACTION_TYPE_INFO { get; set; }
        public string SSCC_LOCATION { get; set; }
        public string DEVICE_ID { get; set; }
        public string LOCATION { get; set; }
        public string SEAL_ID { get; set; }
        public string SHIPMENT_ID { get; set; }
        public string LICENSE_PLATE { get; set; }
        public Nullable<System.DateTime> INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public Nullable<long> TRANSACTION_ID { get; set; }
        public Nullable<int> LOAD_MESSAGE_STATUS_ID { get; set; }
        public Nullable<decimal> XML_ITEM_ID { get; set; }
        public Nullable<long> TRA_ITEM_IN_ID { get; set; }
        public string LOAD_UNIT_SLA_ID { get; set; }
        public Nullable<int> EXPORT_XML { get; set; }
        public string STANDARD_SLA_ID_YN { get; set; }
        public Nullable<int> ACTOR_ORIGIN_ID { get; set; }
        public string TRANSACTION_SUBTYPE { get; set; }
        public string DEPOT_SSCC_LOCATION { get; set; }
        public string ORIGINAL_SSCC_LOCATION { get; set; }
        public string ORIGINAL_SSCC { get; set; }
        public string USER { get; set; }
    }
}
