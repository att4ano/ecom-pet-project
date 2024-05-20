using Domain.Status;

namespace Application.Dto.ModelDto;

public record OrderDto(
    string Address, 
    string? Description, 
    DateTime CreationData, 
    OrderStatus Status, 
    IReadOnlyCollection<OrderItemDto> Items);