using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class SSCCLoadCarrierModel
    {
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string Actor { get; set; }
        public string TransactionType { get; set; }
        public string TransactionSubType { get; set; }
        public string DeviceCode { get; set; }
    }
}
