using Abstractions;
using Application.Dto;
using Application.Dto.EndpointDto;
using Application.Dto.ModelDto;
using Application.Exceptions;
using Application.Mapper;
using Contracts;
using Domain.Services.Interfaces;

namespace Application.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICreateOrderItemService _createOrderItemService;

    public OrderItemService(IOrderItemRepository orderItemRepository, 
        IOrderRepository orderRepository, 
        IProductRepository productRepository, ICreateOrderItemService createOrderItemService)
    {
        _orderItemRepository = orderItemRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _createOrderItemService = createOrderItemService;
    }

    public async Task<IEnumerable<OrderItemDto>> GetAll(ItemFilterDto filterDto)
    {
        var filter = filterDto.ToMapper();
        var items = await _orderItemRepository.GetAll(filter);
        return items.Select(item => item.AsDto()).ToArray();
    }

    public async Task<OrderItemDto?> GetItemById(Guid id)
    {
        var item = await _orderItemRepository.GetById(id);

        if (item is null)
            throw NotFoundException.OrderItemNotFoundException();
        
        return item.AsDto();
    }

    public async Task AddNewItem(AddNewOrderItemDto addNewOrderItemDto)
    {
        var order = await _orderRepository.GetById(addNewOrderItemDto.OrderId);
        var product = await _productRepository.GetById(addNewOrderItemDto.ProductId);

        var orderItem = _createOrderItemService.CreateOrderItem(
            order ?? throw NotFoundException.OrderNotFoundException(),
            product ?? throw NotFoundException.ProductNotFoundException(),
            addNewOrderItemDto.Amount);

        await _orderItemRepository.Add(orderItem);
    }

    public async Task UpdateItemAmount(UpdateItemAmountDto updateItemAmountDto)
    {
        var orderItem = await _orderItemRepository.GetById(updateItemAmountDto.OrderItemId);

        if (orderItem is null)
            throw NotFoundException.OrderItemNotFoundException();
        
        orderItem.Amount = updateItemAmountDto.NewAmount;
        await _orderItemRepository.Update(orderItem);
        
    }

    public async Task DeleteOrderItem(Guid orderItemId)
    {
        await _orderItemRepository.DeleteById(orderItemId);
    }
}   