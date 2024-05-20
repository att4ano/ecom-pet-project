using Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Presentation.Mappers;
using OrderItemGrpc;

namespace Grpc.Presentation.Services;

public class GrpcOrderItemService : OrderItemGrpcService.OrderItemGrpcServiceBase
{
    private readonly IOrderItemService _orderItemService;

    public GrpcOrderItemService(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    public override async Task<GetAllItemsResponse> GetAllItems(ItemFilter request, ServerCallContext context)
    {
        var filter = request.ToDto();
        var result = await _orderItemService.GetAll(filter);
        
        return result.ToResponse();
    }

    public override async Task<OrderItemResponse> GetItemById(GetItemByIdRequest request, ServerCallContext context)
    {
        var id = request.ItemId.ToGuid();
        var result = await _orderItemService.GetItemById(id);

        return result?.ToResponse() ?? throw new InvalidOperationException();
    }

    public override async Task<Empty> AddNewItem(AddNewItemRequest request, ServerCallContext context)
    {
        var addNewItemRequest = request.ToDto();
        await _orderItemService.AddNewItem(addNewItemRequest);

        return new Empty();
    }

    public override async Task<Empty> UpdateItemAmount(UpdateItemAmountRequest request, ServerCallContext context)
    {
        var updateItemAmountRequest = request.ToDto();
        await _orderItemService.UpdateItemAmount(updateItemAmountRequest);

        return new Empty();
    }

    public override async Task<Empty> DeleteItemById(DeleteItemByIdRequest request, ServerCallContext context)
    {
        var id = request.ItemId.ToGuid();
        await _orderItemService.DeleteOrderItem(id);

        return new Empty();
    }
}