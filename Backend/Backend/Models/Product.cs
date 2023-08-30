namespace Backend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        // Navigation property
        public List<OrderItem>? OrderItems { get; set; }
    }
}