using System.ComponentModel.DataAnnotations;

namespace Customer_Relationship_Management_1._0.Models
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Ім'я є обов'язковим")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Країна є обов'язковою")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Номер телефону є обов'язковим")]
        [Phone(ErrorMessage = "Неправильний формат номера телефону")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Електронна пошта є обов'язковою")]
        [EmailAddress(ErrorMessage = "Неправильний формат електронної пошти")]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsApproved { get; set; }
        [Required(ErrorMessage = "Роль є обов'язковою")]
        public string Role { get; set; }
    }
}