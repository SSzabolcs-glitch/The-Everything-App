using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Backend.Models.Customer
{
    public class Address
    {
        public int Id { get; init; }
        public string? Country { get; init; }
        public string? State { get; init; }
        public string? PostalCode { get; init; }
        public string? City { get; init; }
        public string? Sreet { get; init; }
        public int HouseNumber { get; init; }
        public string? Other { get; init; }

        // Foreign key property
        public int UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
