using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    public class Order
    {
        public int Id { get; init; }

        // User Foreign key property
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public int TotalPrice { get; init; }


        // Address Foreign key properties
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public Address? Address { get; set; }
    }
}
