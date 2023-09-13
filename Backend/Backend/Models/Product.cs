using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 99999999.99, ErrorMessage = "Unit price must be between 0.01 and 99999999.99")]
        public decimal UnitPrice { get; set; }
        [Range(1, 9999999999, ErrorMessage = "Quantity must be between 1 and 9999999999")]
        public int Quantity { get; set; }
        public string? ProductImage { get; set; }

        // Navigation property
        //public List<OrderItem>? OrderItems { get; set; }
    }
}