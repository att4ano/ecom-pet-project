namespace Application.Dto.ModelDto;

public record OrderItemDto(Guid Id, Guid OrderId, Guid ProductId, int Amount);