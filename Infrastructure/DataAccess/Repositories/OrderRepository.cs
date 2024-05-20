using Abstractions;
using DataAccess.Context;
using Domain.Models;
using Domain.Models.Builder;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DatabaseContext _context;

    public OrderRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Order>> GetAll(Func<Order, bool> filter)
    {
        var orders = await _context.Orders
            .ToListAsync();

        return orders.Where(filter);
    }

    public async Task<Order?> GetById(Guid id)
    {
        return await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
    }

    public async Task Add(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);

        if (order != null)
            _context.Orders.Remove(order);

        await _context.SaveChangesAsync();
    }
}