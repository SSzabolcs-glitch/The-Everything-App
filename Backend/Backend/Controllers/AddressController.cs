using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Data;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IAddressRepository _addressRepository;

        public AddressController(ILogger<ProductController> logger, IAddressRepository addressRepository)
        {
            _logger = logger;
            _addressRepository = addressRepository;
        }

        [HttpGet("GetAddressById"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Address>> GetAddressByIdAsync(int id)
        {
            try
            {
                var address = await _addressRepository.GetById(id);

                if(address == null)
                {
                    return NotFound($"Address with id {id} not exists");
                }
                return Ok(address);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting address", ex.Message);
                return BadRequest("Error getting address");
            }

        }

        [HttpPost("RegisterNewAddress"), Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Address>> CreateAddress([FromBody] Address address)
        {
            try
            {
                var newAddress = await _addressRepository.AddAddressAsync(address);
                return Ok(newAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering new address", ex.Message);
                return BadRequest("Error registering new address");
            }
        }

    }
}
