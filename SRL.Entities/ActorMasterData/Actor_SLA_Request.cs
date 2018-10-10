using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.ActorMasterData
{
    public class Actor_SLA_Request
    {
        public int LoadUnitId { get; set; }
        public int RTIAcceptance { get; set; }
        public bool StandardSLA { get; set; }
    }
}
