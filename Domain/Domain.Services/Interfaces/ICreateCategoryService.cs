using Domain.Models;

namespace Domain.Services.Interfaces;

public interface ICreateCategoryService
{
    ProductCategory CreateCategory(string name);
}