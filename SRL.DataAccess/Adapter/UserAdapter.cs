using SRL.Data_Access.Entity;
using System.Collections.Generic;
using SRL.Models;

namespace SRL.Data_Access.Adapter
{
    public static class UserAdapter
    {
        internal static SRL.Models.User ToEntityUser(this GetAllUsers_Result user)
        {
            return new Models.User
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsAdmin = user.Admin,
                IsActive = user.Active,
                HasTemplate = user.HasTemplate==1? true:false,
                IsInteranlUser = user.IsInternal,
                Assigned = user.Assigned == 1? true: false,
                RetailerChainCode = user.RetailerChain?? string.Empty
            };
        }

        internal static List<SRL.Models.User> ToEntityUserList(this List<GetAllUsers_Result> users)
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

        internal static SRL.Models.Screen ToEntityScreen(this Data_Access.Entity.sp_GetScreensForUser_Result screen)
        {
            
            return new Models.Screen
            {
                ScreenId = screen.ScreenId,
                ScreenName = screen.ScreenName,
                IsActive = true ,//////as we are fetching only assigned screens. This property would be used in assigning new screen and removing a screen for the user
                RouterLink = screen.RouterLink,
                Level = screen.Level,
                ParentScreenId = screen.ParentScreenId?? 0,
                IsMenuItem = screen.IsMenuItem
            };
        }

        internal static List<SRL.Models.Screen> ToEntityScreenList(this List<Data_Access.Entity.sp_GetScreensForUser_Result> screens)
        {
            List<SRL.Models.Screen> screenList = new List<Models.Screen>();
            if(screens !=null)
            {
                screens.ForEach(screen => screenList.Add(screen.ToEntityScreen()));
            }

            //to get the sub menus
            if(screenList.Count > 0)
            {
                List<SRL.Models.Screen> itemsToBeRemovedFromMain = new List<Models.Screen>();
                foreach(var item in screenList)
                {
                    if(item.Level> 0 && item.ParentScreenId > 0)
                    {
                     //to add the element as child
                     var parent = screenList.Find(s => s.ScreenId == item.ParentScreenId);

                        if (parent != null)
                        {
                            if (parent.Children == null)
                                parent.Children = new List<Models.Screen>();
                            parent.Children.Add(item);
                            //to remove the element from parent list
                            itemsToBeRemovedFromMain.Add(item);
                        }
                    }
                }

                if(itemsToBeRemovedFromMain.Count > 0)
                    itemsToBeRemovedFromMain.ForEach(item=>screenList.Remove(item));
            }
            return screenList;
        }
    }
}
