using System.Collections.Generic;

namespace SRL.Data_Access.Adapter
{
    public static class UserAdapter
    {
        internal static SRL.Entities.User ToEntityUser(this Data_Access.Entity.Users user)
        {
            return new Entities.User
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

        internal static List<SRL.Entities.User> ToEntityUserList(this List<Data_Access.Entity.Users> users)
        {
            List<SRL.Entities.User> userList = new List<Entities.User>();
            if (users != null)
            {
                users.ForEach(user => userList.Add(user.ToEntityUser()));
            }
            return userList;
        }
    }
}
