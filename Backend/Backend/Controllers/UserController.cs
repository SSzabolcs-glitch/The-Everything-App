using Backend.Models;
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
        private readonly UserManager<User> _userManager;
        private readonly IOrderRepository _orderRepository;

        public UserController(IOrderRepository orderRepository, UserManager<User> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        [HttpPost("GetUserOrders")]
        public async Task<ActionResult<List<Order>>> GetUserOrders(string name)
        {

            var user = await _userManager.FindByNameAsync(name);

            List<Order> userOrders = await _orderRepository.GetOrdersByUserIdAsync(user!.Id);

            return userOrders;
        }
    }
}