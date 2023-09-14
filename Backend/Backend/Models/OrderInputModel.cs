namespace Backend.Models;

public class OrderInputModel
{
    public string Address { get; set; }
    public List<OrderItemInputModel> Items { get; set; }
}