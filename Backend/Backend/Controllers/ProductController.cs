using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly EverythingAppDbContext _context;

        public ProductController(ILogger<ProductController> logger, EverythingAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductAsync()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return Ok(products);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error getting products");
                return NotFound("Error getting products");
            }
        }

        [HttpGet("GetSpecificProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetSpecificProductAsync([Required] string name)
        {
           var products = _context.Products.Where(p => p.ProductName == name).ToList();

            if(products.Count == 0)
            {
                return NotFound($"Product {name}  not found");
            }

            try
            {
                return Ok(products);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error getting specific product");
                return NotFound("Error getting specific product");
            }
            
        }
    }
}
