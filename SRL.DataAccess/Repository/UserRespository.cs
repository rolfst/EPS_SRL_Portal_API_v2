using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SRL.Models;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Adapter;
using System.Runtime.Serialization.Json;
using System.Data.Entity.Core.Objects;

namespace SRL.Data_Access
{
    public class UserRespository
    {

        public List<User> GetUsersList(string currentUserRole)
        {
            List<User> users = new List<User>();
            using (var ctx = new SRLManagementEntities())
            {
                // users = (ctx.GetAllUsers(currentUserRole).ToList<Data_Access.Entity.Users>()).ToEntityUserList();
            };
            return users;
        }

        public UserProfile GetUserProfile(string userEmail)
        {
            UserProfile userProfile = new UserProfile();
            if (!string.IsNullOrEmpty(userEmail))
            {
               
                using (var ctx = new SRLManagementEntities())
                {
                  //  userProfile.UserDetail= ctx.sp_GetUserProfile(userEmail);                 

                }

            }
            return userProfile;

        }

        public List<Role> GetUserRoles(string userEmail)
        {
            List<Role> roles = new List<Role>();
            using (var ctx = new SRLManagementEntities())
            {
                roles = ctx.sp_GetUserRoles(userEmail).ToList().ToEntityRoleList(); 
            }
            return roles;
        }

        public List<Screen> GetUserScreens(string userEmail)
        {
            List<Screen> screens = new List<Screen>();
            using (var ctx = new SRLManagementEntities())
            {               
                screens = ctx.sp_GetUserScreens1(userEmail).ToList().ToEntityScreenList();
            }
            return screens;
        }

        public bool IsUserInRole(string userEmail, string[] roles )
        {
            List<Role> roleList = GetUserRoles(userEmail);

            return roleList.Any(r => roles.Contains(r.RoleName));
        }
    }
}
