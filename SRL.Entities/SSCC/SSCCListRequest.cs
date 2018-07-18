using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
    public class SSCCListRequest
    {
        public string ActorID { get; set; }
        public string ActorOriginId { get; set; }
        public bool SsccStatusNew { get; set; }
        public bool SsccStatusProcessed { get; set; }
        public bool SsccStatusValidated { get; set; }
        public DateTime? SsccDateFrom { get; set; }
        public DateTime? SsccDateTo { get; set; }
        public DateTime? CiDateFrom { get; set; }
        public DateTime? CiDateTo { get; set; }
        public bool ValidationOpen { get; set; }
        public bool ValidationExceeded { get; set; }
        public bool ValidationPassed { get; set; }
        public string SsccNr { get; set; }
        public decimal? OrderNr { get; set; }
        public bool CountingOK { get; set; }
        public bool CountingNOK { get; set; }
        public bool SlaOK { get; set; }
        public bool SlaNOK { get; set; }
        public int? RetailerChainId { get; set; }

        public SSCCListRequest(string actorId = null,
            string actorOriginId = null,
            bool ssccStatusNew = false,
            bool ssccStatusProcessed = false,
            bool ssccStatusValidated = false,
            DateTime? ssccDateFrom = null,
            DateTime? ssccDateTo = null,
            DateTime? ciDateFrom = null,
            DateTime? ciDateTo = null,
            bool validationOpen = false,
            bool validationExceeded = false,
            bool validationPassed = false,
            string ssccNr = null,
            decimal? orderNr = 0,
            bool countingOK = false,
            bool countingNOK = false,
            bool slaOK = false,
            bool slaNOK = false,
            int? retailerChainId = -1)
        {
            ActorID = actorId;
            ActorOriginId = actorOriginId;
            SsccStatusNew = ssccStatusNew;
            SsccStatusProcessed = ssccStatusProcessed;
            SsccStatusValidated = ssccStatusValidated;
            SsccDateFrom = ssccDateFrom;
            SsccDateTo = ssccDateTo;
            CiDateFrom = ciDateFrom;
            CiDateTo = ciDateTo;
            ValidationOpen = validationOpen;
            ValidationExceeded = validationExceeded;
            ValidationPassed = validationPassed;
            SsccNr = ssccNr;
            OrderNr = orderNr;
            CountingOK = countingOK;
            CountingNOK = countingNOK;
            SlaOK = slaOK;
            SlaNOK = slaNOK;
            RetailerChainId = retailerChainId;
        }
    }
}
