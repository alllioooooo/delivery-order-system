using Domain.Abstractions.Orders;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;

namespace Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public async Task<IOrder> CreateOrderAsync(IOrder order)
    {
        if (order.OrderId == null)
        {
            order.OrderId = Guid.NewGuid().ToString();
        }
        await orderRepository.AddAsync(order);
        return order;
    }

    public async Task DeleteOrderAsync(string orderId)
    {
        await orderRepository.DeleteAsync(orderId);
    }

    public async Task<IOrder?> GetOrderByIdAsync(string orderId)
    {
        return await orderRepository.GetByIdAsync(orderId);
    }

    public async Task<IEnumerable<IOrder?>> GetAllOrdersAsync()
    {
        return await orderRepository.GetAllAsync();
    }
}