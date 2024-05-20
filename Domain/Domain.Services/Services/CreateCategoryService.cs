using Domain.Models;
using Domain.Services.Interfaces;

namespace Domain.Services.Services;

public class CreateCategoryService : ICreateCategoryService
{
    public ProductCategory CreateCategory(string name)
    {
        return new ProductCategory
        {
            CategoryName = name
        };
    }
}