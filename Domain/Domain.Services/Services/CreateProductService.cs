using Domain.Models;
using Domain.Models.Builder;
using Domain.Services.Interfaces;

namespace Domain.Services.Services;

public class CreateProductService : ICreateProductService
{
    public Product CreateProduct(string name, ProductCategory category, decimal price, string? description)
    {
        return new ProductBuilder()
            .WithProductName(name)
            .WithCategory(category)
            .WithPrice(price)
            .WithDescription(description)
            .Build();
    }
}