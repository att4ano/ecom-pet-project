using Application.Dto;
using Application.Dto.EndpointDto;
using Application.Dto.ModelDto;

namespace Contracts;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItemDto>> GetAll(ItemFilterDto filterDto);

    Task<OrderItemDto?> GetItemById(Guid id);
    
    Task AddNewItem(AddNewOrderItemDto orderItemDto);

    Task UpdateItemAmount(UpdateItemAmountDto updateItemAmountDto);

    Task DeleteOrderItem(Guid orderItemId);
}