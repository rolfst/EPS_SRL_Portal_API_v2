using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class SSCCEditRequest
    {
        public string SSCC { get; set; }
        public decimal OrderNumber { get; set; }
        public string NewOrderNumber { get; set; }
        public decimal? NewOrderNumberNumeric { get; set; }
        public decimal? OldActor { get; set; }
        public decimal? NewActor { get; set; }
        public int LoadMessageStatusId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public List<SSCCEditRTIQty> RTIQuantities { get; set; }
        public string DeleteSSCC { get; set; }
        public string OldSSCC { get; set; }
        public string NewSSCC { get; set; }
        public int TRAItemInId { get; set; }
        public string SLACode { get; set; }
        public string Time { get; set; }
        public string Validation { get; set; }
        public string OldLoadUnitConditionSubCode { get; set; }
        public string NewLoadUnitConditionSubCode { get; set; }
        public string VoidSSCC { get; set; }
        public string OldLoadCarrierEAN { get; set; }
        public string NewLoadCarrierEAN { get; set; }
        public List<SSCCEditAnomaly> Anomalies { get; set; }

    }

}
