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
    
    public partial class SLA_UNIT_INFO_DETAILS
    {
        public int LOAD_UNIT_SLA_ID { get; set; }
        public int ACTOR_ID { get; set; }
        public int LOAD_UNIT_ID { get; set; }
        public int ACTOR_TYPE_ID { get; set; }
        public string RETAILER_CHAIN { get; set; }
        public Nullable<decimal> MAX { get; set; }
        public Nullable<decimal> MIN { get; set; }
        public string UNIT { get; set; }
        public string TYPE { get; set; }
        public Nullable<int> THEORETICAL_WEIGHT { get; set; }
        public System.DateTime LOAD_UNIT_SLA_INSERT_DATE { get; set; }
        public string LOAD_UNIT_SLA_INSERT_USER { get; set; }
        public System.DateTime LOAD_UNIT_SLA_UPDATE_DATE { get; set; }
        public string LOAD_UNIT_SLA_UPDATE_USER { get; set; }
        public int LOAD_UNIT_SORT { get; set; }
        public int LOAD_CARRIER_ID { get; set; }
        public int SORTING_STATUS_ID { get; set; }
        public Nullable<int> STACKING_HEIGHT { get; set; }
        public Nullable<int> NUMBER_STACKS { get; set; }
        public Nullable<decimal> STANDARD_VOLUME { get; set; }
        public Nullable<int> NUMBER_SEU { get; set; }
        public System.DateTime LOAD_UNIT_INSERT_DATE { get; set; }
        public System.DateTime LOAD_UNIT_UPDATE_DATE { get; set; }
        public string LOAD_UNIT_CODE { get; set; }
        public string LOAD_UNIT_UPDATE_USER { get; set; }
        public string LOAD_UNIT_INSERT_USER { get; set; }
        public string LOAD_UNIT_NAME { get; set; }
        public int LOAD_CARRIER_SORT { get; set; }
        public string LOAD_CARRIER_CODE { get; set; }
        public int LOAD_CARRIER_LENGTH { get; set; }
        public int LOAD_CARRIER_WIDTH { get; set; }
        public decimal LOAD_CARRIER_VOLUME { get; set; }
        public int LOAD_CARRIER_WEIGHT { get; set; }
        public int LOAD_CARRIER_HEIGHT { get; set; }
        public System.DateTime LOAD_CARRIER_INSERT_DATE { get; set; }
        public string LOAD_CARRIER_INSERT_USER { get; set; }
        public System.DateTime LOAD_CARRIER_UPDATE_DATE { get; set; }
        public string LOAD_CARRIER_UPDATE_USER { get; set; }
        public string LOAD_CARRIER_NAME { get; set; }
        public string TRANSLATION_DETAILS_LANGUAGE { get; set; }
    }
}
