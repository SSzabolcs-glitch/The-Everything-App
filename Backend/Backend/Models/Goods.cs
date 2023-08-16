namespace Backend.Models
{
    public class Goods
    {
        public int ItemId { get; set; }

        public string? ProductName { get; set; }

        public int UnitPrice { get; set; }

        public int Inventory { get; set; }
    }
}