using Domain.Models;

namespace Domain.Services.Interfaces;

public interface ICreateOrderService
{
    Order CreateOrder(Dictionary<Product, int> cart, string address, string description);
}