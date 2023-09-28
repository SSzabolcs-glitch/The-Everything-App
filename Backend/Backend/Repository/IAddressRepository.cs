using Backend.Models;

namespace Backend.Repository;

public interface IAddressRepository
{
    Task<Address?> GetById(int id);
    Task<Address> AddAddressAsync(Address address);
    Task<Address> DeleteAsync(int addressId);
    Task<Address> UpdateAsync(int addressId, Address freshAddress);
}