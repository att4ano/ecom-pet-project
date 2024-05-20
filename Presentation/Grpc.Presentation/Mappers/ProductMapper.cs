using Application.Dto.EndpointDto;
using Application.Dto.FilterDto;
using Application.Dto.ModelDto;
using Microsoft.IdentityModel.Tokens;
using ProductGrpc;

namespace Grpc.Presentation.Mappers;

public static class ProductMapper
{

    public static ProductFilterDto ToDto(this ProductFilter filter)
    {
        long? price = null;
        
        if (filter.Price is not null)
        {
            price = filter.Price.Value;
        }
        
        if (!filter.CategoryId.IsNullOrEmpty())
        {
            return new ProductFilterDto(
                filter.CategoryId.ToGuid(), 
                price);
        }

        return new ProductFilterDto(
            null,
            price);
    }
    
    public static ProductResponse ToResponse(this ProductDto product)
    {
        return new ProductResponse
        {
            ProductId = product.Id.ToString(),
            Name = product.Name,
            CategoryId = product.CategoryId.ToString(),
            Description = product.Description,
            Price = product.Price.ToProto()
        };
    }

    public static GetProductListResponse ToResponse(this IEnumerable<ProductDto> products)
    {
        var result = new GetProductListResponse();
        result.Product.AddRange(products.Select(product => product.ToResponse()));

        return result;
    }

    public static CreateProductDto ToDto(this CreateProductRequest request)
    {
        return new CreateProductDto(
            request.Name,
            request.CategoryId.ToGuid(),
            request.Price.ToDecimal(),
            request.Description);
    }

    public static CreateProductCategoryDto ToDto(this CreateProductCategoryRequest request)
    {
        return new CreateProductCategoryDto(request.Name);
    }

    public static UpdateProductPriceDto ToDto(this UpdateProductPriceRequest request)
    {
        return new UpdateProductPriceDto(
            request.ProductId.ToGuid(),
            request.Price.ToDecimal());
    }
}
