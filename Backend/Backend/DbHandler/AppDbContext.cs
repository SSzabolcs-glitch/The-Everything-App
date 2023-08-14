using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSet for Customer entity
    public DbSet<Customer> Customers { get; set; }

    // Other DbSet properties for other entities, if any

}



