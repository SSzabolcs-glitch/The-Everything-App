using Backend.Models.Customer;
using Backend.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DatabaseTest.Controllers
{
    [Route("api")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public AdminController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/customers
        [HttpGet("customers")]
        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                return _customerRepository.GetAll();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Customer>();
            }
        }

        // GET: api/customer
        [HttpGet("customer")]
        public Customer GetCustomer(string firstname, string lastname)
        {
            try
            {
                var result = _customerRepository.GetByName(firstname, lastname);
                return result;
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException("Customer not found.");
            }
        }

        // GET: api/customer
        [HttpPut("customer")]
        public void UpdateCustomer(string firstname, string lastname)
        {
            try
            {
                var customer = _customerRepository.GetByName(firstname, lastname);
                _customerRepository.Update(customer);
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException("Customer not found.");
            }
        }

        // GET: api/customer
        [HttpDelete("customer")]
        public void DeleteCustomer(string firstname, string lastname)
        {
            try
            {
                var customer = _customerRepository.GetByName(firstname, lastname);
                _customerRepository.Delete(customer);
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException("Customer not found.");
            }
        }
    }
}