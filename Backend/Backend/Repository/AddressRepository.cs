using Backend.Models;
using Backend.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly IDbContextFactory<EverythingAppContext> _dbContextFactory;

    public AddressRepository(IDbContextFactory<EverythingAppContext> dbContextFactory)
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