using Abstractions;
using DataAccess.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DatabaseContext _context;

    public ProductRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll(Func<Product, bool> filter)
    {
        var products = await _context.Product
            .ToListAsync();
        
        return products.Where(filter);
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await _context.Product.FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task Add(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var product = await _context.Product.FirstOrDefaultAsync(product => product.Id == id);

        if (product != null)
            _context.Product.Remove(product);

        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
    }
}