using Application.Dto;
using Application.Dto.EndpointDto;
using Application.Dto.ModelDto;
using OrderItemGrpc;

namespace Grpc.Presentation.Mappers;

public static class ItemMapper
{

    public static ItemFilterDto ToDto(this ItemFilter filter)
    {
        return new ItemFilterDto(
            filter.ProductId.ToGuid(), 
            filter.CategoryId.ToGuid());
    }

    public static AddNewOrderItemDto ToDto(this AddNewItemRequest request)
    {
        return new AddNewOrderItemDto(
            request.OrderId.ToGuid(),
            request.ProductId.ToGuid(),
            request.Amount);
    }

    public static OrderItemResponse ToResponse(this OrderItemDto item)
    {
        return new OrderItemResponse
        {
            ItemId = item.Id.ToString(),
            OrderId = item.OrderId.ToString(),
            ProductId = item.ProductId.ToString(),
            Amount = item.Amount,
        };
    }
    
    public static GetAllItemsResponse ToResponse(this IEnumerable<OrderItemDto> items)
    {
        var result = new GetAllItemsResponse();
        var itemsResponse = items.Select(item => item.ToResponse());
        result.Items.AddRange(itemsResponse);

        return result;
    }

    public static UpdateItemAmountDto ToDto(this UpdateItemAmountRequest request)
    {
        return new UpdateItemAmountDto(
            request.ItemId.ToGuid(),
            request.Amount);
    }
}
