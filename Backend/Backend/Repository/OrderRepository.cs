using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _dbContext.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.User)  // Include the related user data
                .Include(o => o.BillingAddress)  // Include the related address data
                .ToListAsync();

            return orders;
        }
    }
}
