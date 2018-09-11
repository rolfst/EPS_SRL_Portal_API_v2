using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.Order
{
   public class NonValidatedOrder
    {
        public string OrderNumber { get; set; }
        public List<string> SSCCs { get; set; }

    }
}
