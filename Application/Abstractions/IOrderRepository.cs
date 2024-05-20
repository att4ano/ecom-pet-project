using Domain.Models;

namespace Abstractions;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAll(Func<Order, bool> filter);

    Task<Order?> GetById(Guid id);

    Task Add(Order order);

    Task DeleteById(Guid id);
}