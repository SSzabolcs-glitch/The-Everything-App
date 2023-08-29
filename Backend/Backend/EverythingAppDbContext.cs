using Backend.Models.Customer;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class EverythingAppDbContext : DbContext
{
    private readonly string? _connectionString;
    public EverythingAppDbContext(DbContextOptions<EverythingAppDbContext> options, IConfiguration configuration) : base(options)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
    public DbSet<Customer> Customers { get; init; }
    public DbSet<Address> Addresses { get; init; }
    public DbSet<Product> Products { get; init; }
    public DbSet<Order> Orders { get; init; }
    public DbSet<OrderItem> OrderItems { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();
        
        builder.Entity<Product>()
            .HasIndex(c => c.ItemId)
            .IsUnique();

        builder.Entity<Product>()
        .HasData(
            new Product { Id = 1, ItemId = 1234, ProductName = "pencil", Quantity = 65, UnitPrice = 120 },
            new Product { Id = 2, ItemId = 2234, ProductName = "pen", Quantity = 498, UnitPrice = 300 },
            new Product { Id = 3, ItemId = 3234, ProductName = "erasure", Quantity = 560, UnitPrice = 99 },
            new Product { Id = 4, ItemId = 4234, ProductName = "scissors", Quantity = 67, UnitPrice = 1200 }
            );

        builder.Entity<Customer>()
            .HasOne(c => c.Address)
            .WithOne(ss => ss.Customer)
            .HasForeignKey<Address>(ss => ss.CustomerId);

        builder.Entity<Order>()
            .HasIndex(o => o.Id)
            .IsUnique();

        builder.Entity<OrderItem>()
            .HasIndex(o => o.Id)
            .IsUnique();
    }

}