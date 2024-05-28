namespace Customer_Relationship_Management_1._0.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsApproved { get; set; }
        public string Role { get; set; }
    }
}