using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRL.Entities;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Adapter;

namespace SRL.Data_Access
{
    public class UserRespository
    {

        public List<User> GetUsersList()
        {
            List<User> users = new List<User>();
            using (var ctx = new SRLManagementEntities())
            {
                users = (ctx.GetAllUsers().ToList<Data_Access.Entity.Users>()).ToEntityUserList();
            };
            return users;
        }

    }
}
