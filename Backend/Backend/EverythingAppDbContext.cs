using Backend.Models;
using Backend.Models.Customer;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>()
        .HasIndex(c => c.Email)
        .IsUnique();
    }

}