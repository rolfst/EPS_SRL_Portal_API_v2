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
    
    public partial class LOAD_CARRIER_TRANSLATION
    {
        public int LOAD_CARRIER_TRANSLATION_ID { get; set; }
        public int LOAD_CARRIER_ID { get; set; }
        public int TRANSLATION_ID { get; set; }
        public string LOAD_CARRIER_NAME { get; set; }
    
        public virtual LOAD_CARRIER LOAD_CARRIER { get; set; }
        public virtual TRANSLATION_DETAILS TRANSLATION_DETAILS { get; set; }
    }
}
