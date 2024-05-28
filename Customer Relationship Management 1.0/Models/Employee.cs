namespace Customer_Relationship_Management_1._0.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}