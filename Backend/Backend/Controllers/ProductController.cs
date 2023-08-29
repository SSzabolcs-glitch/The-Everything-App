﻿using Backend.Models;
using Backend.Services.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                var products = _productRepository.GetAll();
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
           var products = _productRepository.GetByName(name);

            if(products.IsNullOrEmpty())
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

        [HttpPost("AddNewProduct")]
        public async Task<ActionResult> AddNewProduct(Product product)
        {
            try
            {
                _productRepository.Add(product);
                 return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering new product");
                return BadRequest("Error registering new product");
            }
        }
    }
}
