using Abstractions;
using Application.Dto;
using Application.Dto.EndpointDto;
using Application.Dto.FilterDto;
using Application.Dto.ModelDto;
using Application.Mapper;
using Contracts;
using Domain.Services.Interfaces;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly ICreateCategoryService _createCategoryService;
    private readonly ICreateProductService _createProductService;

    public ProductService(IProductRepository productRepository, 
        IProductCategoryRepository productCategoryRepository, 
        ICreateCategoryService createCategoryService, 
        ICreateProductService createProductService)
    {
        _productRepository = productRepository;
        _productCategoryRepository = productCategoryRepository;
        _createCategoryService = createCategoryService;
        _createProductService = createProductService;
    }
    
    public async Task<IEnumerable<ProductDto>> GetAll(ProductFilterDto filterDto)
    {
        var filter = filterDto.ToMapper();
        var products = await _productRepository.GetAll(filter);
        return products.Select(product => product.AsDto()).ToArray();
    }

    public async Task<ProductDto?> GetById(Guid id)
    {
        var product = await _productRepository.GetById(id);
        return product?.AsDto();
    }

    public async Task CreateProduct(CreateProductDto createProductDto)
    {
        var category = await _productCategoryRepository.GetById(createProductDto.CategoryId);

        if (category is not null)
        {
            await _productRepository.Add(_createProductService.CreateProduct(
                createProductDto.Name, 
                category, 
                createProductDto.Price, 
                createProductDto.Description));
        }
    }

    public async Task CreateProductCategory(CreateProductCategoryDto createProductCategoryDto)
    {
        await _productCategoryRepository.Add(_createCategoryService.CreateCategory(createProductCategoryDto.Name));
    }

    public async Task UpdateProductPrice(UpdateProductPriceDto updateProductPriceDto)
    {
        var product = await _productRepository.GetById(updateProductPriceDto.ProductId);
        if (product is not null)
        {
            product.Price = updateProductPriceDto.Price;
            await _productRepository.Update(product);
        }
    }

    public async Task DeleteProduct(Guid productId)
    {
        await _productRepository.DeleteById(productId);
    }
}