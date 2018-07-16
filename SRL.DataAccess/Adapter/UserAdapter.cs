using System.Collections.Generic;

namespace SRL.Data_Access.Adapter
{
    public static class UserAdapter
    {
        internal static SRL.Models.User ToEntityUser(this Data_Access.Entity.Users user)
        {
            return new Models.User
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsAdmin = user.Admin,
                IsActive = user.Active,
                IsInvited = user.Invited,
                HasAccepted = user.Accepted,
                Language = user.Language,
                IsInteranlUser = user.IsInternal,
                Assigned = user.Assigned
            };
        }

        internal static List<SRL.Models.User> ToEntityUserList(this List<Data_Access.Entity.Users> users)
        {
            List<SRL.Models.User> userList = new List<Models.User>();
            if (users != null)
            {
                users.ForEach(user => userList.Add(user.ToEntityUser()));
            }
            return userList;
        }

        internal static SRL.Models.Role ToEntityRole(this Data_Access.Entity.sp_GetUserRoles_Result role)
        {
            return new Models.Role
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                RolePriority = role.RolePriority ?? 0,
                IsActive = true ///as we are fetching only active roles. This property would be used in adding new user and deactivating a role for the user
                
            };
        }

        internal static List<SRL.Models.Role> ToEntityRoleList(this List<Data_Access.Entity.sp_GetUserRoles_Result> roles)
        {
            List<SRL.Models.Role> roleList = new List<Models.Role>();
            if(roles != null)
            {
                roles.ForEach(role => roleList.Add(role.ToEntityRole()));
            }
            return roleList;
        }

        internal static SRL.Models.Screen ToEntityScreen(this Data_Access.Entity.sp_GetUserScreens1_Result screen)
        {
            return new Models.Screen
            {
                ScreenId = screen.ScreenId,
                 ScreenName = screen.ScreenName,
                 IsActive = true ,//////as we are fetching only assigned screens. This property would be used in assigning new screen and removing a screen for the user
                 RouterLink = screen.RouterLink
            };
        }

        internal static List<SRL.Models.Screen> ToEntityScreenList(this List<Data_Access.Entity.sp_GetUserScreens1_Result> screens)
        {
            List<SRL.Models.Screen> screenList = new List<Models.Screen>();
            if(screens !=null)
            {
                screens.ForEach(screen => screenList.Add(screen.ToEntityScreen()));
            }
            return screenList;
        }
    }
}
