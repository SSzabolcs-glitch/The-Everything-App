using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

using Backend.Models;
using Microsoft.AspNetCore.Identity;


[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly EverythingAppContext _context;
    private readonly UserManager<User> _userManager;

    public OrderController(EverythingAppContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost("create")]
    public IActionResult CreateOrder([FromBody] OrderInputModel orderInput)
    {
        try
        {
            // Validate the incoming data (e.g., check if the address is not empty, etc.)
            if (string.IsNullOrWhiteSpace(orderInput.Address) || orderInput.Items == null || orderInput.Items.Count == 0)
            {
                return BadRequest("Invalid order data");
            }



            // Create an Order object from the input data
            var order = new Order
            {
                // ShippingAddress = orderInput.Address,
                // User = user,
                ShippingAddressId = 1,
                BillingAddressId = 1,
                TotalPrice = (int)orderInput.Items.Sum(item => item.UnitPrice * item.Quantity)
            };

            // Add the order to the database context and save changes
            _context.Orders.Add(order);
            _context.SaveChanges();

            // Create OrderItem objects and associate them with the order
            foreach (var itemInput in orderInput.Items)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductName == itemInput.ProductName);
                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    TotalPrice = itemInput.UnitPrice,
                    Quantity = itemInput.Quantity,
                    OrderId = order.Id
                };

                _context.OrderItems.Add(orderItem);
            }

            // Save changes to persist the order items
            _context.SaveChanges();

            return Ok("Order created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}