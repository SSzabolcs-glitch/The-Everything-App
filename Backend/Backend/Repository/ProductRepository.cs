using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EverythingAppContext _dbContext;
        public ProductRepository(EverythingAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var users = await _dbContext.Products.ToListAsync();
            return users;
        }

        public async Task<IEnumerable<Product?>> GetByNameAsync(string productName)
        {
            var userByName = await _dbContext.Products.Where(c => c.ProductName == productName).ToListAsync();
            return userByName;
        }
        public async Task<Product> AddAsync(Product product)
        {
            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> DeleteAsync(Product product)
        {
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteByIdAsync(int id)
        {
            var product = await _dbContext.Products.FirstAsync(p => p.Id == id);
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var productToUpdate = await _dbContext.Products.FirstAsync(p => p.Id == id);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.Quantity = product.Quantity;
            await _dbContext.SaveChangesAsync();

            return productToUpdate;
        }
    }
}
