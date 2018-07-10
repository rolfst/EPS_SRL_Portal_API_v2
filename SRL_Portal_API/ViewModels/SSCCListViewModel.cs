using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRL_Portal_API.ViewModels
{
    public class SSCCListViewModel
    {
        public DateTime? OrderDate { get; set; }
        public string SSCC { get; set; }
        public string ActorFrom { get; set; }
        public string ActorTo { get; set; }
        public string SsccStatus { get; set; }
        public double ValidationDeadline { get; set; }
        public bool SlaOK { get; set; }
        public bool CountingOK { get; set; }
        public DateTime? CIDate { get; set; }
        public bool IsValidated { get; set; }
        public string ValidationStatus { get; set; }
    }
}