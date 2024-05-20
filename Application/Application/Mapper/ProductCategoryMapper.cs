using Application.Dto.ModelDto;
using Domain.Models;

namespace Application.Mapper;

public static class ProductCategoryMapper
{
    public static ProductCategoryDto AsDto(this ProductCategory productCategory)
        => new ProductCategoryDto(productCategory.CategoryName);
}