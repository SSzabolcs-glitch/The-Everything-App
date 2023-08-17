using Backend.Models;
using Backend.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly IDbContextFactory<EverythingAppDbContext> _dbContextFactory;

    public AddressRepository(IDbContextFactory<EverythingAppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
  

    public Address? GetByCustomerId(int customerId)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        return dbContext.Addresses.FirstOrDefault(a => a.Id == customerId);
    }

    public void Delete(Address address)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        dbContext.Addresses.Remove(address);
        dbContext.SaveChanges();
    }

    public void Update(Address address)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        dbContext.Addresses.Update(address);
        dbContext.SaveChanges();
    }

    public void AddAddress(Address address)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        dbContext.Addresses.Add(address);
        dbContext.SaveChanges();
    }
}