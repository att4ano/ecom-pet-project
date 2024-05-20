using Application.Services;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection collection)
    {
        collection.AddScoped<IOrderService, OrderService>();
        collection.AddScoped<IProductService, ProductService>();
        collection.AddScoped<IOrderItemService, OrderItemService>();

        return collection;
    }
}