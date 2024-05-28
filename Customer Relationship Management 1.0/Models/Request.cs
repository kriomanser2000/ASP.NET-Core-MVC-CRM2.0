namespace Customer_Relationship_Management_1._0.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RequestDate { get; set; }
    }
}