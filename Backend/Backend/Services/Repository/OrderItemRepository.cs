using Backend.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Repository;

public class OrderItemRepository:IOrderItemRepository
{
    private readonly IDbContextFactory<EverythingAppDbContext> _dbContextFactory;

    public OrderItemRepository(IDbContextFactory<EverythingAppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public OrderItem? GetByOrderId(int orderId)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        return dbContext.OrderItems.FirstOrDefault(oi => oi.OrderId == orderId);
    }

    public void Delete(OrderItem orderItem)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        dbContext.OrderItems.Remove(orderItem);
        dbContext.SaveChanges();
    }

    public void Update(OrderItem orderItem)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        dbContext.OrderItems.Update(orderItem);
        dbContext.SaveChanges();
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        dbContext.OrderItems.Add(orderItem);
        dbContext.SaveChanges();
    }
}