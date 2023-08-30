using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<EverythingAppContext> _dbContextFactory;

        public ProductRepository(IDbContextFactory<EverythingAppContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public IEnumerable<Product> GetAll()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Products.ToList();
        }

        public Product? GetByName(string productName)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Products.FirstOrDefault(c => c.ProductName == productName);
        }
        public void Add(Product product)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Add(product);
            dbContext.SaveChanges();
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
