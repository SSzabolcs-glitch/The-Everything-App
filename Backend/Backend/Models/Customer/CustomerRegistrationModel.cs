using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Customer
{
    public class CustomerRegistrationModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(6)] // Ide Lehet hozzáadni plusz szabályokat pl: szám, speciális karakter. 
        public string? Password { get; set; }
    }
}
