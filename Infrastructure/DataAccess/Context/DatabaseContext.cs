using DataAccess.Configurations;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DbSet<Product> Product { get; init; } = null!;
    public DbSet<ProductCategory> ProductCategory { get; init; } = null!;
    public DbSet<Order> Orders { get; init; } = null!;
    public DbSet<OrderItem> OrderItem { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
       
        base.OnModelCreating(modelBuilder);
    }
}
