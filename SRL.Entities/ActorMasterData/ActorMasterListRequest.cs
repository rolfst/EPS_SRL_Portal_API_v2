using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.ActorMasterData
{
   public class ActorMasterListRequest
    {
        public string ActorName { get; set; }
        public decimal? ActorCode { get; set; }
        public string RetailerChainId { get; set; }
        public string Location { get; set; }
    }
}
