using Domain.Models;

namespace Domain.Services.Interfaces;

public interface IOrderStatusService
{
     void CancelOrder(Order order);

     void CompleteOrder(Order order);
}
