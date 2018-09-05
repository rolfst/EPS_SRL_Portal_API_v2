using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.ActorMasterData
{
   public class Actor_SLA
    {
        public int LoadUnitSLAId { get; set; }
        public int LoadUnitId { get; set; }
        public string LoadUnitCode { get; set; }
        public decimal? RTIAcceptance { get; set; }
        public Boolean Linked { get; set; }
    }
}
