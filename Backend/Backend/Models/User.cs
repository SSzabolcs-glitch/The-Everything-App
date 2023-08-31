using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    public class User : IdentityUser<string>
    {
        public string? DisplayName { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
