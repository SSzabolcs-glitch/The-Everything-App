namespace Backend.Models;

public class OrderItemInputModel
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
}