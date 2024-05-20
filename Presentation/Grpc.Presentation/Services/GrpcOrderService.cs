using Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Presentation.Mappers;
using OrderGrpc;

namespace Grpc.Presentation.Services;

public class GrpcOrderService : OrderGrpcService.OrderGrpcServiceBase
{
    private readonly IOrderService _orderService;

    public GrpcOrderService(IOrderService orderService)
    {
        _orderService = orderService;
    }


    public override async Task<GetOrderListResponse> GetOrderList(OrderFilter request, ServerCallContext context)
    {
        var filter = request.ToDto();
        var result = await _orderService.GetAll(filter);
        var response = new GetOrderListResponse();
        response.Order.AddRange(result.Select(order => order.ToResponse()));

        return response;
    }

    public override async Task<OrderResponse> GetOrderById(GetOrderByIdRequest request, ServerCallContext context)
    {
        var id = request.OrderId.ToGuid();
        var result = await _orderService.GetById(id);

        return result?.ToResponse() ?? throw new InvalidOperationException();
    }

    public override async Task<Empty> CreateOrder(CreateOrderRequest request, ServerCallContext context)
    {
        var createOrderRequest = request.ToDto();
        await _orderService.CreateOrder(createOrderRequest);

        return new Empty();
    }

    public override async Task<Empty> CancelOrder(ChangeStatusOrderRequest request, ServerCallContext context)
    {
        var id = request.OrderId.ToGuid();
        await _orderService.CancelOrder(id);

        return new Empty();
    }

    public override async Task<Empty> CompleteOrder(ChangeStatusOrderRequest request, ServerCallContext context)
    {
        var id = request.OrderId.ToGuid();
        await _orderService.CompleteOrder(id);

        return new Empty();
    }
}