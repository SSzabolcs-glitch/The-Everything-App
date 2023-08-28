using Backend.Models.Customer;
using Microsoft.EntityFrameworkCore;


namespace Backend.Services.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContextFactory<EverythingAppDbContext> _dbContextFactory;

        public OrderRepository(IDbContextFactory<EverythingAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public IEnumerable<Order> GetAll()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Orders.ToList();
        }

        public Order? GetById(int id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return dbContext.Orders.FirstOrDefault(c => c.Id == id);
        }
        public void Add(Order order)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Add(order);
            dbContext.SaveChanges();
        }
        public void Delete(Order order)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Remove(order);
            dbContext.SaveChanges();
        }

        public void Update(Order order)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Update(order);
            dbContext.SaveChanges();
        }
    }
}
