namespace Backend.Models
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
    }
}
