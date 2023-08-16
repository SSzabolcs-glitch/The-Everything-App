using Backend.Models.Customer;

namespace Backend.Services.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer? GetByName(string firstname, string lastname);
        void Delete(Customer customer);
        void Update(Customer customer);
    }
}
