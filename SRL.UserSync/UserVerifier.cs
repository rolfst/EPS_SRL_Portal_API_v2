using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Repository;
using SRL.Models;

namespace SRL.UserSync
{
    internal class UserVerifier
    {
        private readonly UserRepository _userRepository = new UserRepository();

        /// <summary>
        /// Verifies if each user is still active in Active Directory
        /// </summary>
        /// <param name="users">A list of users which are available in Active Directory</param>
        /// <param name="originalUsers">A list of users which are existing in the database</param>
        /// <returns>A <see cref="IEnumerable{Users}"/> containing all verified users</returns>
        internal IEnumerable<Users> VerifyUsersInAd(IEnumerable<User> users, IEnumerable<Users> originalUsers)
        {
            var verifiedUsers = originalUsers.Where(x => users.Select(y => y.Email).Contains(x.Email));
            return verifiedUsers;
        }
    }
}
