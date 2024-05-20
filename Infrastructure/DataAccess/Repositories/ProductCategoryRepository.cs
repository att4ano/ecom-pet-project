using Abstractions;
using DataAccess.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly DatabaseContext _context;

    public ProductCategoryRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProductCategory>> GetAll()
    {
        return await _context.ProductCategory.ToListAsync();
    }

    public async Task<ProductCategory?> GetById(Guid id)
    {
        return await _context.ProductCategory.FirstOrDefaultAsync(category => category.Id == id);
    }

    public async Task Add(ProductCategory category)
    {
        _context.ProductCategory.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var category = await _context.ProductCategory.FirstOrDefaultAsync(category => category.Id == id);

        if (category != null)
            _context.ProductCategory.Remove(category);

        await _context.SaveChangesAsync();
    }
}