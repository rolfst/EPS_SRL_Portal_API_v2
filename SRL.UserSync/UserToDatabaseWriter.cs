using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Repository;
using SRL.Models;

namespace SRL.UserSync
{
    internal class UserToDatabaseWriter
    {
        private readonly UserRepository _repository = new UserRepository();

        internal void WriteUsersToDatabase(IEnumerable<User> users)
        {
            var originalUsers = _repository.GetAllUsers();

            var newUsers = users.Where(x => !originalUsers.Select(y => y.Email).Contains(x.Email) );
            _repository.AddUsers(newUsers);
        }
    }
}
