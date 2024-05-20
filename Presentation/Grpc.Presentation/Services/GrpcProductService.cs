using Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Presentation.Mappers;
using ProductGrpc;

namespace Grpc.Presentation.Services;

public class GrpcProductService : ProductGrpcService.ProductGrpcServiceBase
{
    private readonly IProductService _productService;

    public GrpcProductService(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task<GetProductListResponse> GetProductList(ProductFilter request, ServerCallContext context)
    {
        var filter = request.ToDto();
        var result = await _productService.GetAll(filter);

        return result.ToResponse();
    }

    public override async Task<ProductResponse> GetProductById(GetProductByIdRequest request, ServerCallContext context)
    {
        var id = request.ProductId.ToGuid();
        var result = await _productService.GetById(id);

        return result?.ToResponse() ?? throw new InvalidOperationException();
    }

    public override async Task<Empty> CreateProduct(CreateProductRequest request, ServerCallContext context)
    {
        var createProductRequest = request.ToDto();
        await _productService.CreateProduct(createProductRequest);

        return new Empty();
    }

    public override async Task<Empty> CreateProductCategory(CreateProductCategoryRequest request, ServerCallContext context)
    {
        var createCategoryRequest = request.ToDto();
        await _productService.CreateProductCategory(createCategoryRequest);

        return new Empty();
    }

    public override async Task<Empty> UpdateProductPrice(UpdateProductPriceRequest request, ServerCallContext context)
    {
        var updateProductPriceRequest = request.ToDto();
        await _productService.UpdateProductPrice(updateProductPriceRequest);

        return new Empty();
    }

    public override async Task<Empty> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
    {
        var id = request.ProductId.ToGuid();
        await _productService.DeleteProduct(id);

        return new Empty();
    }
}