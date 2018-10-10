using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models
{
   public class UserListRequest
    {
        public string ViewingUserEmail{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? IsAssigned { get; set; }
        public bool? IsActive { get; set; }
        public bool? HasTemplate { get; set; }
        public bool? IsAdmin { get; set; }
        public string RetailerChainCode { get; set; }
        public bool? IsInternal { get; set; }
    }
}
