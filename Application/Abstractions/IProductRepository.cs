using Domain.Models;

namespace Abstractions;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll(Func<Product, bool> filter);

    Task<Product?> GetById(Guid id);

    Task Add(Product product);

    Task DeleteById(Guid id);

    Task Update(Product product);
}