using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.Order
{
   public class SSCCsForOrder
    {
        public List<string> ContainerNames { get; set; }
        public List<SSCCDetailForOrder> SSCCs { get; set; }

    }
}
