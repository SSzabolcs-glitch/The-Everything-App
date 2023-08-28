using Backend.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Repository
{
    public class CustomerService : ICustomerRepository
    {
        private readonly IDbContextFactory<EverythingAppDbContext> _dbContextFactory;

        public CustomerService(IDbContextFactory<EverythingAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public IEnumerable<Customer> GetAll()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Customers.ToList();
        }

        public Customer? GetByName(string firstname, string lastname)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Customers.FirstOrDefault(c => c.FirstName == firstname && c.LastName == lastname);
        }
        public void Delete(Customer customer)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Remove(customer);
            dbContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Update(customer);
            dbContext.SaveChanges();
        }
    }
}
