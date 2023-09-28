using Backend.Models;

namespace Backend.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product?>> GetByNameAsync(string productName);
        Task<Product> AddAsync(Product product);
        Task<Product> DeleteAsync(Product product);
        Task<Product> DeleteByIdAsync(int id);
        Task<Product> UpdateProductAsync(int id, Product product);
    }
}
