using Domain.Models;

namespace Abstractions;

public interface IOrderItemRepository
{
    Task<IEnumerable<OrderItem>> GetAll(Func<OrderItem, bool> filter);

    Task<OrderItem?> GetById(Guid id);
    
    Task Update(OrderItem orderItem);

    Task Add(OrderItem item);

    Task DeleteById(Guid id);
}