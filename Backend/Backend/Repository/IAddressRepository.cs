using Backend.Models;

namespace Backend.Repository;

public interface IAddressRepository
{
    Address? GetByCustomerId(int customerid);
    void Delete(Address address);
    void Update(Address address);
    void AddAddress(Address address);
}