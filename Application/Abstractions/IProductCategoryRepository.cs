using Domain.Models;

namespace Abstractions;

public interface IProductCategoryRepository
{
    Task<IEnumerable<ProductCategory>> GetAll();

    Task<ProductCategory?> GetById(Guid id);

    Task Add(ProductCategory category);

    Task DeleteById(Guid id);
}
