using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    public class Order
    {
        public int Id { get; set; }

        // User Foreign key property
        public string? UserId { get; set; }
        public User? User { get; set; }
        public decimal? TotalPrice { get; set; }

        
        // Address Foreign key properties
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public Address? Address { get; set; }
    }
}
