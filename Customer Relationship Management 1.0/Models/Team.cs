namespace Customer_Relationship_Management_1._0.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }

}