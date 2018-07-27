using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class SSCCDeviationsModel
    {
        public DateTime? TransactionDateTime { get; set; }
        public List<string> DeviationReasonList { get; set; }
    }
}
