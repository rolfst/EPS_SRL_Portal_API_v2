using System.Collections.Generic;

namespace SRL.Models
{
   public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public List<string> Roles { get; set; }

    }
}
