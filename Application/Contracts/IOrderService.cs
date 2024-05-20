using Application.Dto;
using Application.Dto.ModelDto;
using Domain.Models;

namespace Contracts;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAll(OrderFilterDto filterDto);

    Task<OrderDto?> GetById(Guid id);

    Task CreateOrder(CreateOrderDto orderDto);

    Task CancelOrder(Guid orderId);

    Task CompleteOrder(Guid orderId);
}