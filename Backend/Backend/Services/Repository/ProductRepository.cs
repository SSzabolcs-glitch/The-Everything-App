using Backend.Models;
using Backend.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<EverythingAppDbContext> _dbContextFactory;

        public ProductRepository(IDbContextFactory<EverythingAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Products.ToList();
        }

        public async Task<IEnumerable<Product?>> GetByNameAsync(string productName)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Products.Where(c => c.ProductName == productName).ToList();
        }
        public async Task<Product> AddAsync(Product product)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Add(product);
            dbContext.SaveChanges();
            return product;
        }
        public void Delete(Product product)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Remove(product);
            dbContext.SaveChanges();
        }

        public void Update(Product product)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Update(product);
            dbContext.SaveChanges();
        }
    }
}
