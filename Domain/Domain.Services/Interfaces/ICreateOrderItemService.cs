using Domain.Models;

namespace Domain.Services.Interfaces;

public interface ICreateOrderItemService
{
    OrderItem CreateOrderItem(Order order, Product product, int amount);
}