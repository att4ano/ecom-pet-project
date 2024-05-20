using Abstractions;
using DataAccess.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly DatabaseContext _context;

    public OrderItemRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderItem>> GetAll(Func<OrderItem, bool> filter)
    {
        var items = await _context.OrderItem
            .ToListAsync();

        return items
            .Where(filter);
    }

    public async Task<OrderItem?> GetById(Guid id)
    {
        return await _context.OrderItem.FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task Update(OrderItem orderItem)
    {
        _context.OrderItem.Update(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task Add(OrderItem item)
    {
        _context.OrderItem.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var item = await _context.OrderItem.FirstOrDefaultAsync(item => item.Id == id);

        if (item != null)
            _context.OrderItem.Remove(item);

        await _context.SaveChangesAsync();
    }
}