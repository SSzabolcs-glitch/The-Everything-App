using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly EverythingAppContext _dbContext;

    public AddressRepository(EverythingAppContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Address?> GetById(int id)
    {
        var address = await _dbContext.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        return address;
    }
    public async Task<Address> AddAddressAsync(Address address)
    {
        await _dbContext.Addresses.AddAsync(address);
        await _dbContext.SaveChangesAsync();
        return address;
    }

    public async Task<Address> DeleteAsync(int addressId)
    {
        var addressToDelete = await _dbContext.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);
        if(addressToDelete == null)
        {
            throw new Exception("Nonexistent address");
        }
        _dbContext.Addresses.Remove(addressToDelete);
        await _dbContext.SaveChangesAsync();
        return addressToDelete;
    }

    public async Task<Address> UpdateAsync(int addressId, Address freshAddress)
    {
        var addressToUpdate = await _dbContext.Addresses.FirstOrDefaultAsync(address => address.Id == addressId);   
        if(addressToUpdate == null)
        {
            throw new Exception("Nonexistent address");
        }

        addressToUpdate.Country = freshAddress.Country;
        addressToUpdate.State = freshAddress.State;
        addressToUpdate.Street = freshAddress.Street;
        addressToUpdate.PostalCode = freshAddress.PostalCode;
        addressToUpdate.City = freshAddress.City;
        addressToUpdate.HouseNumber = freshAddress.HouseNumber;
        addressToUpdate.Other = freshAddress.Other;

        await _dbContext.SaveChangesAsync();
        return addressToUpdate;
    }

}