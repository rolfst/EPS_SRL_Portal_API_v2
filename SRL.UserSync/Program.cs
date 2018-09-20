using SRL.Data_Access.Repository;

namespace SRL.UserSync
{
    public class Program
    {
        private static UserToDatabaseWriter UserToDatabaseWriter;
        private static UserRetriever UserRetriever;
        public static void Main(string[] args)
        {
            UserToDatabaseWriter = new UserToDatabaseWriter();
            UserRetriever = new UserRetriever();

            var users = UserRetriever.RetrieveUsers();
            UserToDatabaseWriter.WriteUsersToDatabase(users);
        }
    }
}
