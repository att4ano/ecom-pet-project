using Domain.Models;
using Domain.Models.Builder;
using Domain.Services.Interfaces;

namespace Domain.Services.Services;

public class CreateOrderService : ICreateOrderService
{
    public Order CreateOrder(Dictionary<Product, int> cart, string address, string description)
    {
        var order = new OrderBuilder()
            .WithAddress(address)
            .WithDescription(description)
            .WithCreationData(DateTime.Now)
            .Build();

        foreach (var item in cart)
        {
            order.Items.Add(new OrderItemBuilder()
                .WithProductItem(item.Key)
                .WithOrder(order)
                .WithAmount(item.Value)
                .Build());
        }

        return order;
    }
}