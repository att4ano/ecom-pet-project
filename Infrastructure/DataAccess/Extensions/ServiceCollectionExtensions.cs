using Abstractions;
using DataAccess.Context;
using DataAccess.Repositories;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection collection,
        Action<DbContextOptionsBuilder> configuration)
    {
        collection.AddDbContext<DatabaseContext>(configuration);
        
        collection.AddScoped<IOrderRepository, OrderRepository>();
        collection.AddScoped<IOrderItemRepository, OrderItemRepository>();
        collection.AddScoped<IProductRepository, ProductRepository>();
        collection.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

        return collection;
    }

    public static IServiceCollection AddMigrations(
        this IServiceCollection collection,
        string? connectionString)
    {
        collection.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb.AddPostgres()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(DatabaseContext).Assembly).For.Migrations()
            ).AddLogging(lb => lb.AddFluentMigratorConsole());

        return collection;
    }
}
