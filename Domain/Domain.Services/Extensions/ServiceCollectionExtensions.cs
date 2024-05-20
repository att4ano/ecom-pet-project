using Domain.Services.Interfaces;
using Domain.Services.Services;

namespace Domain.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection collection)
    {
        collection.AddScoped<IOrderStatusService, OrderStatusService>();
        collection.AddScoped<ICreateCategoryService, CreateCategoryService>();
        collection.AddScoped<ICreateProductService, CreateProductService>();
        collection.AddScoped<ICreateOrderService, CreateOrderService>();
        collection.AddScoped<ICreateOrderItemService, CreateOrderItemService>();
        
        return collection;
    }
}
