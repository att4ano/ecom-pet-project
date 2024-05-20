using Application.Dto;
using Application.Dto.EndpointDto;
using Application.Dto.FilterDto;
using Application.Dto.ModelDto;
using Domain.Models;

namespace Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAll(ProductFilterDto filterDto);

    Task<ProductDto?> GetById(Guid id);

    Task CreateProduct(CreateProductDto createProductDto);

    Task CreateProductCategory(CreateProductCategoryDto createProductCategoryDto);

    Task UpdateProductPrice(UpdateProductPriceDto updateProductPriceDto);

    Task DeleteProduct(Guid productId);
}