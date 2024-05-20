using Domain.Models;

namespace Domain.Services.Interfaces;

public interface ICreateProductService
{
    Product CreateProduct(string name, ProductCategory category, decimal price, string? description);
}