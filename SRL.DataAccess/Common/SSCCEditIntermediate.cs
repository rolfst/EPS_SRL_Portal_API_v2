using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRL.Data_Access.Common
{
    public class SSCCEditIntermediate
    {
        public string SSCC { get; set; }
        public decimal OrderNumber { get; set; }
        public decimal? NewOrderNumber { get; set; }
        public decimal? OldActor { get; set; }
        public decimal? NewActor { get; set; }
        public int LoadMessageStatusId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public string OldLoadUnitConditionCode { get; set; }
        public string NewLoadUnitConditionCode { get; set; }
        public int? OldQtyRTI { get; set; }
        public int? NewQtyRTI { get; set; }
        public decimal? ESoftPackingId { get; set; }
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

    }

}
