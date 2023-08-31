using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

public class EverythingAppContext : IdentityDbContext<User, IdentityRole, string>
{
    public DbSet<Address> Addresses { get; init; }
    public DbSet<Product> Products { get; init; }
    public DbSet<Order> Orders { get; init; }
    public DbSet<OrderItem> OrderItems { get; init; }

    private readonly string? _connectionString;
    public EverythingAppContext(DbContextOptions<EverythingAppContext> options, IConfiguration configuration) : base(options)
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships for OrderItem entity
        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => oi.Id);

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.TotalPrice)
            .HasColumnType("decimal(10, 2)");

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany()
            .HasForeignKey(oi => oi.OrderId);

        // Configure relationships for Order entity
        modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany()
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Address)
            .WithMany()
            .HasForeignKey(o => o.ShippingAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Address)
            .WithMany()
            .HasForeignKey(o => o.BillingAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure relationships for Address entity
        modelBuilder.Entity<Address>()
            .HasKey(a => a.Id);

        // Configure Product
        modelBuilder.Entity<Product>()
            .Property(p => p.UnitPrice)
            .HasColumnType("decimal(5, 2)");
    }

}