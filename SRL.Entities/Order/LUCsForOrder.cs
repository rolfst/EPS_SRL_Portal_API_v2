using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.Order
{
   public class LUCsForOrder
    {
        public List<string> LoadUnitConditionNames { get; set; }
        public List<SSCCLoadUnitCondition> LoadUnitConditions { get; set; }
    }
}
