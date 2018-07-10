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
    
    public partial class TRANSACTION_DEL
    {
        public long TRANSACTION_ID { get; set; }
        public string SSCC { get; set; }
        public long SSCC_ID { get; set; }
        public Nullable<decimal> FIRST_SSCC_USAGE { get; set; }
        public Nullable<decimal> END_SSCC_USAGE { get; set; }
        public Nullable<int> ACTOR_ID { get; set; }
        public string DEVICE_CODE { get; set; }
        public int ACTION_ID { get; set; }
        public int LOAD_UNIT_SLA_ID { get; set; }
        public Nullable<decimal> TRANSACTION_DATE { get; set; }
        public string TRANSACTION_TIME { get; set; }
        public string TRANSACTION_TYPE_ID { get; set; }
        public Nullable<decimal> ORDER_NUMBER { get; set; }
        public string SHIPMENT_NUMBER { get; set; }
        public string SEAL_NUMBER { get; set; }
        public string LICENSE_PLATE { get; set; }
        public string CONFIRMATION { get; set; }
        public int NUMBER_SSCC_ON_ORDER { get; set; }
        public int STACKING_HEIGHT { get; set; }
        public int NUMBER_STACKS { get; set; }
        public int MEASURED_LENGTH { get; set; }
        public int MEASURED_WIDTH { get; set; }
        public int MEASURED_HEIGHT { get; set; }
        public int MEASURED_VOLUME { get; set; }
        public int MEASURED_WEIGHT { get; set; }
        public int ESTIMATED_SEU_MISSING { get; set; }
        public int RESULT_NUMBER_SEU { get; set; }
        public int TOT_QTY_RTI_COUNTED { get; set; }
        public decimal TOT_SEU_RECALCULATED { get; set; }
        public int TOT_WEIGHT_RTI_CALCULATED { get; set; }
        public int TOT_LOAD_UNIT_WEIGHT_CALCULATED { get; set; }
        public int TOT_VOLUME_RTI_CALCULATED { get; set; }
        public int TOT_LOAD_UNIT_VOLUME_CALCULATED { get; set; }
        public bool DECICIVE_CI_IND { get; set; }
        public string LAST_SSCC_OPEN_YN { get; set; }
        public long TRA_ITEM_IN_ID { get; set; }
        public int LOAD_MESSAGE_STATUS_ID { get; set; }
        public string LOAD_SOURCE { get; set; }
        public System.DateTime INSERT_DATE { get; set; }
        public string INSERT_USER { get; set; }
        public System.DateTime UPDATE_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public string SSCC_LOCATION { get; set; }
        public Nullable<int> COUNTED_GRAI { get; set; }
        public Nullable<decimal> CALCULATED_HEIGHT { get; set; }
        public Nullable<int> ACTOR_ORIGIN_ID { get; set; }
        public Nullable<int> EXPORT_XML { get; set; }
        public int TOT_QTY_RTI_COUNTED_Inbound_DC { get; set; }
        public decimal TOT_SEU_RECALCULATED_Inbound_DC { get; set; }
        public int TOT_QTY_RTI_COUNTED_Outbound_Shop { get; set; }
        public decimal TOT_SEU_RECALCULATED_Outbound_Shop { get; set; }
        public int TOT_QTY_RTI_COUNTED_Outbound_DC { get; set; }
        public decimal TOT_SEU_RECALCULATED_Outbound_DC { get; set; }
        public string TRANSACTION_SUBTYPE { get; set; }
        public string ORIGINAL_SSCC_LOCATION { get; set; }
        public string LOCATION { get; set; }
        public string ORIGINAL_SSCC { get; set; }
        public Nullable<int> LOAD_EXPORT_STATUS_ID { get; set; }
        public Nullable<decimal> LOAD_CARRIER_EAN { get; set; }
        public bool CLOSE_ORDER { get; set; }
        public string DEPOT_ORDER_NUMBER { get; set; }
        public string USER { get; set; }
        public Nullable<int> MONO_SSCC_TRAILER { get; set; }
        public string AUDIT_USER { get; set; }
        public System.DateTime AUDIT_TIMESTAMP { get; set; }
    }
}
