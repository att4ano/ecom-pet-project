using Application.Dto.ModelDto;
using Domain.Models;

namespace Application.Mapper;

public static class OrderItemMapper
{
    public static OrderItemDto AsDto(this OrderItem orderItem)
        => new OrderItemDto(orderItem.Id, orderItem.OrderId, orderItem.ProductId, orderItem.Amount);
}