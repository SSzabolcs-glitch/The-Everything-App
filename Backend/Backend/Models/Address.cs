using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Backend.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Sreet { get; set; }
        public int HouseNumber { get; set; }
        public string? Other { get; set; }
    }
}
