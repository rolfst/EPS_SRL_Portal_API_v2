using System.Collections.Generic;

namespace SRL.Models
{
    /// <summary>
    /// Screen object to be used for navigation
    /// </summary>
   public class Screen
    {
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public bool IsActive { get; set; }

        public string RouterLink { get; set; }

        public int Level { get; set; }

        public int ParentScreenId { get; set; }

        public List<Screen> Children { get; set; }
    }
}
