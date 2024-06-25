using Domain.Abstractions.Orders;
using Domain.Abstractions.Repositories;
using Domain.Models.Orders;
using Infrastructure.DataAccess.DbContext;
using Infrastructure.DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    public async Task AddAsync(IOrder order)
    {
        context.Orders.Add((Order)order);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string orderId)
    {
        var order = await context.Orders.FindAsync(orderId);
        if (order != null)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IOrder?> GetByIdAsync(string orderId)
    {
        return await context.Orders.FindAsync(orderId);
    }

    public async Task<IEnumerable<IOrder?>> GetAllAsync()
    {
        return await context.Orders.ToListAsync();
    }
}