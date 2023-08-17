using Backend.Models.Customer;

namespace Backend.Services.Repository;

public interface IOrderItemRepository
{
    OrderItem? GetByOrderId(int orderid);
    void Delete(OrderItem orderItem);
    void Update(OrderItem orderItem);
    void AddOrderItem(OrderItem orderItem);
}