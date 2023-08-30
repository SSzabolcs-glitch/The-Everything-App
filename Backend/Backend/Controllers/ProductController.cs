using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        //private readonly EverythingAppDbContext _context;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
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
            var products = await _productRepository.GetByNameAsync(name);

            if (products.IsNullOrEmpty())
            {
                return NotFound($"Product {name} not found");
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

        [HttpPost("AddNewProduct"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddNewProductAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                return Ok($"{product.ProductName} added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering new product");
                return BadRequest("Error registering new product");
            }
        }

        /*
        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult> DeleteProductAsync(Product product)
        {
            try
            {
                await _productRepository.DeleteAsync(product);
                return Ok($"{product.ProductName} deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product");
                return BadRequest("Error deleting product");
            }
        }
        */

        [HttpDelete("DeleteProductById"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProductByIdAsync([Required] int id)
        {
            try
            {
                var product = await _productRepository.DeleteByIdAsync(id);
                return Ok($"{product.ProductName} deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product");
                return BadRequest("Error deleting product");
            }
        }

        [HttpPut("UpdateProduct"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProduct([Required] int id, Product freshProduct)
        {
            try
            {
                var product = await _productRepository.UpdateProductAsync(id, freshProduct);
                return Ok($"Id: {product.Id}, ({product.ProductName}) updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product");
                return BadRequest("Error updating product");
            }
        }
    }
}