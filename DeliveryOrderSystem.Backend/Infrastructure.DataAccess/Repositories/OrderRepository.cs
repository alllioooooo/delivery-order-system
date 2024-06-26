using AutoMapper;
using Domain.Abstractions.Orders;
using Domain.Abstractions.Repositories;
using Infrastructure.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public OrderRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddAsync(IOrder order)
    {
        var entity = _mapper.Map<Entities.Order>(order);
        _context.Orders.Add(entity);
        await _context.SaveChangesAsync();
        _mapper.Map(entity, order);
    }

    public async Task DeleteAsync(string orderId)
    {
        var entity = await _context.Orders.FindAsync(orderId);
        if (entity != null)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IOrder?> GetByIdAsync(string orderId)
    {
        var entity = await _context.Orders.FindAsync(orderId);
        return _mapper.Map<IOrder>(entity);
    }

    public async Task<IEnumerable<IOrder>> GetAllAsync()
    {
        var entities = await _context.Orders.ToListAsync();
        return _mapper.Map<IEnumerable<IOrder>>(entities);
    }
}