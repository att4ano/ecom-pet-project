namespace Domain.Models.Builder;

using System;

public class ProductBuilder
{
    private string? _productName;
    private Guid _categoryId;
    private ProductCategory? _category;
    private decimal _price;
    private string? _description;

    public ProductBuilder WithProductName(string productName)
    {
        _productName = productName;
        return this;
    }

    public ProductBuilder WithCategory(ProductCategory category)
    {
        _category = category;
        _categoryId = category.Id;
        return this;
    }

    public ProductBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public ProductBuilder WithDescription(string? description)
    {
        _description = description;
        return this;
    }

    public Product Build()
    {
        return new Product
        {
            ProductName = _productName ?? throw new ArgumentNullException(nameof(_productName), "cannot be null"),
            CategoryId = _categoryId,
            Category = _category ?? throw new ArgumentNullException(nameof(_category), "cannot be null"),
            Price = _price,
            Description = _description,
        };
    }
}
