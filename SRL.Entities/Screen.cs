using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models
{
   public class Screen
    {
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public bool IsActive { get; set; }

        public string RouterLink { get; set; }
    }
}
