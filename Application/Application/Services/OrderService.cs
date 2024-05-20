using Abstractions;
using Application.Dto;
using Application.Dto.ModelDto;
using Application.Exceptions;
using Application.Mapper;
using Contracts;
using Domain.Models;
using Domain.Services.Interfaces;

namespace Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICreateOrderService _createOrderService;
    private readonly IOrderStatusService _orderStatusService;

    public OrderService(ICreateOrderService createOrderService,
        IOrderStatusService orderStatusService,
        IOrderRepository orderRepository,
        IProductRepository productRepository)
    {
        _createOrderService = createOrderService;
        _orderStatusService = orderStatusService;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<OrderDto>> GetAll(OrderFilterDto filterDto)
    {
        var filter = filterDto.ToMapper();
        var orders = await _orderRepository.GetAll(filter);
        return orders.Select(order => order.AsDto()).ToArray();
    }

    public async Task<OrderDto?> GetById(Guid id)
    {
        var order = await _orderRepository.GetById(id);
        
        if (order is null)
            throw NotFoundException.OrderNotFoundException();
            
        return order.AsDto();
    }

    public async Task CreateOrder(CreateOrderDto orderDto)
    {
        var productItems = new Dictionary<Product, int>();

        foreach (var item in orderDto.Items)
        {
            var product = await _productRepository.GetById(item.Key);
            productItems.Add(
                product ?? throw NotFoundException.ProductNotFoundException(),
                item.Value);
        }

        await _orderRepository.Add(
            _createOrderService.CreateOrder(productItems, orderDto.Address, orderDto.Description));
    }

    public async Task CancelOrder(Guid orderId)
    {
        var order = await _orderRepository.GetById(orderId);

        if (order is not null)
        {
            _orderStatusService.CancelOrder(order);
        }
    }

    public async Task CompleteOrder(Guid orderId)
    {
        var order = await _orderRepository.GetById(orderId);
        _orderStatusService.CompleteOrder(order ?? throw NotFoundException.OrderNotFoundException());
    }
}