namespace SRL.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsInvited { get; set; }
        public bool HasTemplate { get; set; }
        public bool IsInteranlUser { get; set; }
        public bool Assigned { get; set; }
        public int RetailerChainCode { get; set; }
    }
}
