using System.Collections.Generic;

namespace SRL.Models
{
   public class UserProfile
    {
        public User UserDetail { get; set; }

        public List<Role> Roles { get; set; }

        public List<Screen> Screens { get; set; }

    }
}
