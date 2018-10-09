using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.Order
{
   public class SSCCLoadUnitCondition
    {
        public string SSCC { get; set; }
        public List<LoadUnitCondition> LoadUnitConditions { get; set; }
    }
}
