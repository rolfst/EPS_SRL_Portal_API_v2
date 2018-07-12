using System.Collections.Generic;
using SRL.Models;

namespace SRL.Data_Access.Adapter
{
    public static class UserAdapter
    {
        internal static User ToEntityUser(this Data_Access.Entity.Users user)
        {
            return new User
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

        internal static List<User> ToEntityUserList(this List<Data_Access.Entity.Users> users)
        {
            List<User> userList = new List<User>();
            if (users != null)
            {
                users.ForEach(user => userList.Add(user.ToEntityUser()));
            }
            return userList;
        }
    }
}
