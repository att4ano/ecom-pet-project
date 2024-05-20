using Application.Dto.ModelDto;
using Domain.Models;

namespace Application.Mapper;

public static class OrderMapper
{
    public static OrderDto AsDto(this Order order)
        => new OrderDto(order.Address,
            order.Description,
            order.CreationData,
            order.Status,
            order.Items.Select(item => item.AsDto()).ToArray());

}