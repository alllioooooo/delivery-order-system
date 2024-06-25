using Domain.Abstractions.Orders;

namespace Domain.Abstractions.Services;

public interface IOrderService
{
    Task<IOrder> CreateOrderAsync(IOrder order);
    Task<IOrder?> GetOrderByIdAsync(string orderId);
    Task<IEnumerable<IOrder?>> GetAllOrdersAsync();
    Task DeleteOrderAsync(string orderId);
}