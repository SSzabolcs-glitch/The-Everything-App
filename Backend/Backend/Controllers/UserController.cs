using Backend.Models.Customer;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DatabaseTest.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet("GetUsers"), Authorize(Roles = "Admin")]
        public async Task<IEnumerable<IdentityUser>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAll();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Users.");
                throw;
            }
        }
    }
}