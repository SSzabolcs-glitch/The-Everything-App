using Backend.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EverythingAppContext _dbContext;

        public OrderRepository(EverythingAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order? GetById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(c => c.Id == id);
        }
        public void Add(Order order)
        {
            _dbContext.Add(order);
            _dbContext.SaveChanges();
        }
        public void Delete(Order order)
        {
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public void Update(Order order)
        {
            _dbContext.Update(order);
            _dbContext.SaveChanges();
        }
    }
}
