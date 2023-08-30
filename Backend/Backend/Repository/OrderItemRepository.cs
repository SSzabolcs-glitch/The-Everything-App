using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly EverythingAppContext _dbContext;

    public OrderItemRepository(EverythingAppContext dbContext)
    {
        _dbContext = dbContext;
    }

    public OrderItem? GetByOrderId(int orderId)
    {
        return _dbContext.OrderItems.FirstOrDefault(oi => oi.OrderId == orderId);
    }

    public void Delete(OrderItem orderItem)
    {
        _dbContext.OrderItems.Remove(orderItem);
        _dbContext.SaveChanges();
    }

    public void Update(OrderItem orderItem)
    {
        _dbContext.OrderItems.Update(orderItem);
        _dbContext.SaveChanges();
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        _dbContext.OrderItems.Add(orderItem);
        _dbContext.SaveChanges();
    }
}