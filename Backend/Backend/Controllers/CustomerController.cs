using Backend.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTest.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EverythingAppDbContext _context;

        public CustomerController(EverythingAppDbContext context)
        {
            _context = context;
        }

        // POST: api/customer/register
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] CustomerRegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                // Nézze meg hogy az email már foglalt
                if (await _context.Customers.AnyAsync(c => c.Email == registrationModel.Email))
                {
                    return BadRequest("Email is already registered.");
                }

                var newCustomer = new Customer
                {
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    Email = registrationModel.Email
                };

                newCustomer.SetPassword(registrationModel.Password); // Setteljük a Hashelt jelszót

                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();

                return Ok("Registration successful.");
            }

            return BadRequest("Invalid registration data.");
        }
    }
}