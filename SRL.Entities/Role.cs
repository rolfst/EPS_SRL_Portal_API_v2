using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models
{
   public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public int RolePriority { get; set; }
    }
}
