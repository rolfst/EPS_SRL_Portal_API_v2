using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.ActorMasterData
{
   public class ActorMasterListResponse
    {
        public int ActorId { get; set; }
        public decimal ActorCode { get; set; }
        public string ActorName { get; set; }
        public string ActorLocation { get; set; }
        public string RetailerChain { get; set; }
        public string  ActorType { get; set; }
    }
}
