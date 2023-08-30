using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;

namespace DatabaseTest.Controllers
{
    [Route("api")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(ILogger<UserController> logger, IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpGet("GetUsers"), Authorize(Roles = "Admin")]
        public async Task<IEnumerable<IdentityUser>> GetUsers()
        {
            try
            {
                var users = await _userManager.GetUsersInRoleAsync("User");
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Users.");
                throw;
            }
        }

        [HttpGet("GetUser"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<IdentityUser>> GetUser(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting User.");
                throw;
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(string email, IdentityUser user)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser == null) return NotFound();

                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;

                var result = await _userManager.UpdateAsync(existingUser);

                return Ok($"Updated {existingUser}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating User.");
                throw;
            }
        }

        [HttpDelete("DeleteUser"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(email);
                if(user == null)
                {
                    return NotFound();
                }
                else
                {
                    await _userManager.DeleteAsync(user);
                    return Ok($"User {user.UserName} Deleted.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting User.");
                throw;
            }
        }
    }
}