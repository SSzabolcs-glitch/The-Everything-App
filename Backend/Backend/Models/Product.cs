using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Product
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public string? ProductName { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}