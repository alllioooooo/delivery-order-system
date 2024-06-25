using Domain.Abstractions.Orders;

namespace Domain.Abstractions.Repositories;

public interface IOrderRepository
{
    Task<IOrder?> GetByIdAsync(string orderId);
    Task AddAsync(IOrder order);
    Task DeleteAsync(string orderId);
    Task<IEnumerable<IOrder?>> GetAllAsync();
}