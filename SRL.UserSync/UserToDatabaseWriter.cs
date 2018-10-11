using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Repository;
using SRL.Models;

namespace SRL.UserSync
{
    internal class UserToDatabaseWriter
    {
        private readonly UserRepository _userRepository = new UserRepository();

        internal void WriteUsersToDatabase(IEnumerable<User> users, IEnumerable<Users> originalUsers, int createdUserId)
        {
            var newUsers = users.Where(x => !originalUsers.Select(y => y.Email).Contains(x.Email) );
            _userRepository.AddUsers(newUsers, createdUserId);
        }

        internal void DeactivateUnverifiedUsersFromDatabase(IEnumerable<Users> unverifiedUsers, int modifiedUserId)
        {
            _userRepository.DeactivateUsers(unverifiedUsers, modifiedUserId);
        }
    }
}
