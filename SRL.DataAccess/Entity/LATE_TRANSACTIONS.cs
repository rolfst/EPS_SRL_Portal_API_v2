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
    
    public partial class LATE_TRANSACTIONS
    {
        public long LATETRANSACTION_ID { get; set; }
        public string SSCC { get; set; }
        public Nullable<System.DateTime> TRANSACTION_DATE { get; set; }
        public string TRANSACTION_TYPE_ID { get; set; }
        public string TRANSACTION_SUBTYPE { get; set; }
        public Nullable<System.DateTime> FILE_DATETIME { get; set; }
        public long TRA_ITEM_IN_ID { get; set; }
    }
}
