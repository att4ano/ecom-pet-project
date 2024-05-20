using Application.Dto.ModelDto;
using Domain.Models;

namespace Application.Mapper;

public static class ProductMapper
{
    public static ProductDto AsDto(this Product product)
        => new ProductDto(
            product.Id,
            product.ProductName,
            product.CategoryId,
            product.Price,
            product.Description);
}