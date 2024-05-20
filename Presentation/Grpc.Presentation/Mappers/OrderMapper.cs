using System.Globalization;
using Application.Dto;
using Application.Dto.ModelDto;
using Domain.Status;
using OrderGrpc;

namespace Grpc.Presentation.Mappers;

public static class OrderMapper
{
    public static CreateOrderDto ToDto(this CreateOrderRequest request)
    {
        var map = new Dictionary<Guid, int>();
        foreach (var item in request.Items.Keys)
        {
            map[Guid.Parse(item)] = request.Items[item];
        }

        return new CreateOrderDto(
            map, 
            request.Address, 
            request.Description);
    }
    
    public static OrderResponse ToResponse(this OrderDto orderDto)
    {
        var response = new OrderResponse
        {
            Description = orderDto.Description,
            CreationData = orderDto.CreationData.ToString(CultureInfo.InvariantCulture),
            Address = orderDto.Address,
            Status = orderDto.Status.ToString()
        };
        
        response.Items.AddRange(orderDto.Items.Select(item => item.Id.ToString()));

        return response;
    }

    public static OrderFilterDto ToDto(this OrderFilter filter)
    {
        return new OrderFilterDto(
            DateTime.Parse(filter.CreationData),
            Enum.Parse<OrderStatus>(filter.Status));
    }
}
