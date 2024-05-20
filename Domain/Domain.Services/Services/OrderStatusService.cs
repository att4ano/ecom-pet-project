using Domain.Models;
using Domain.Models.Builder;
using Domain.Services.Interfaces;

namespace Domain.Services.Services;

public class OrderStatusService : IOrderStatusService
{
    public void CancelOrder(Order order)
    {
        order.CancelOrder();
    }

    public void CompleteOrder(Order order)
    {
        order.CompleteOrder();
    }
}
