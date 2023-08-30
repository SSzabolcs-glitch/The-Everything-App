using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.Customer
{
    public class OrderItem
    {
        public int Id { get; init; }

        // Foreign key property
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        // Foreign key property
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int Quantity { get; init; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? UnitPrice { get; init; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPrice { get; init; }
    }
}
