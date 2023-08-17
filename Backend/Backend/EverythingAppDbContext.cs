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

        builder.Entity<Customer>()
            .HasOne(c => c.Address)
            .WithOne(ss => ss.Customer)
            .HasForeignKey<Address>(ss => ss.CustomerId);
    }

}