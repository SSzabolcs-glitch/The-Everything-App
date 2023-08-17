using Backend.Models;

namespace Backend.Services.Repository
{
    public interface IPruductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetByName(string productName);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
