using Backend.Models;

namespace Backend.Services.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product?>> GetByNameAsync(string productName);
        Task<Product> AddAsync(Product product);
        Task<Product> DeleteAsync(Product product);
        Task<Product> DeleteByIdAsync(int id);
        void Update(Product product);
    }
}
