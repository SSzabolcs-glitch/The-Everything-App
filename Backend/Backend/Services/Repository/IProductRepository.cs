using Backend.Models;

namespace Backend.Services.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product?>> GetByNameAsync(string productName);
        Task<Product> AddAsync(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
