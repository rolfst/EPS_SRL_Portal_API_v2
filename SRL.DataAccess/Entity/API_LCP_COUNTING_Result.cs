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
    
    public partial class API_LCP_COUNTING_Result
    {
        public string SSCC { get; set; }
        public string COUNTING_TYPE { get; set; }
        public string RTI_NAME { get; set; }
        public int QTY_RTI { get; set; }
        public string LOAD_CARRIER_NAME { get; set; }
        public string UNIT { get; set; }
        public Nullable<decimal> RETURNED_VALUE { get; set; }
        public Nullable<decimal> EXPECTED_VALUE_MIN { get; set; }
        public Nullable<decimal> EXPECTED_VALUE_MAX { get; set; }
        public string ACTOR_ORIGIN { get; set; }
    }
}
