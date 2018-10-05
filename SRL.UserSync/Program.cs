using System.Linq;
using SRL.Data_Access.Repository;

namespace SRL.UserSync
{
    public class Program
    {
        private static readonly UserRepository UserRepository = new UserRepository();

        private static UserRetriever _userRetriever;
        private static UserVerifier _userVerifier;
        private static UserToDatabaseWriter _userToDatabaseWriter;
        public static void Main(string[] args)
        {
            _userRetriever = new UserRetriever();
            _userVerifier = new UserVerifier();
            _userToDatabaseWriter = new UserToDatabaseWriter();

            var users = _userRetriever.RetrieveUsers().ToList();
            var originalUsers = UserRepository.GetAllUsers();
            var autoUserId = _userRetriever.RetrieveCreatedUser().UserId;

            var verifiedUsers = _userVerifier.VerifyUsersInAd(users, originalUsers);
            var unverifiedUsers = originalUsers.Where(x => !verifiedUsers.Select(y => y.Email).Contains(x.Email));
            _userToDatabaseWriter.RemoveUnverifiedUsersFromDatabase(unverifiedUsers, autoUserId);
            _userToDatabaseWriter.WriteUsersToDatabase(users, originalUsers, autoUserId);
        }
    }
}
