using Backend.Models;

namespace Backend.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order? GetById(int id);
        void Add(Order order);
        void Delete(Order order);
        void Update(Order order);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
