using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SRL.Data_Access.Repository;
using SRL.Models;

namespace SRL.UserSync
{
    internal class UserRetriever
    {
        private readonly ActiveDirectoryUserRepository _activeDirectoryRepository = new ActiveDirectoryUserRepository();
        private readonly UserRepository _userRepository = new UserRepository();

        internal IEnumerable<User> RetrieveUsers()
        {
            return _activeDirectoryRepository.GetUsers();
        }

        internal User RetrieveCreatedUser()
        {
            return _userRepository.GetUsersList(new UserListRequest
                {Email = ConfigurationManager.AppSettings["b2c:CreatedEmail"]}).First();
        }
    }
}
