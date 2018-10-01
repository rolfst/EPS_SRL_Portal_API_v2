using System.Collections.Generic;
using SRL.Data_Access.Repository;
using SRL.Models;

namespace SRL.UserSync
{
    internal class UserRetriever
    {
        private readonly ActiveDirectoryRepository _repo = new ActiveDirectoryRepository();

        internal IEnumerable<User> RetrieveUsers()
        {
            return _repo.GetUsers();
        }
    }
}
