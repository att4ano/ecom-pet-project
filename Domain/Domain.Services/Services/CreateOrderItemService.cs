using Domain.Models;
using Domain.Models.Builder;
using Domain.Services.Interfaces;

namespace Domain.Services.Services;

public class CreateOrderItemService : ICreateOrderItemService
{
    public OrderItem CreateOrderItem(Order order, Product product, int amount)
    {
        return new OrderItemBuilder()
            .WithOrder(order)
            .WithAmount(amount)
            .WithProductItem(product)
            .Build();
    }
}