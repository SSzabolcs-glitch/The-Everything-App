using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    public class Order
    {
        public int Id { get; set; }

        // User Foreign key property
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        
        // Shipping Address Foreign key property
        public int? ShippingAddressId { get; set; }
        public Address? ShippingAddress { get; set; } // Navigation property for shipping address

        // Billing Address Foreign key property
        public int? BillingAddressId { get; set; }
        public Address? BillingAddress { get; set; } // Navigation property for billing address
        public decimal? TotalPrice { get; set; }
    }
}
