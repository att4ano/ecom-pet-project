namespace Application.Dto.EndpointDto;

public record AddNewOrderItemDto(Guid OrderId, Guid ProductId, int Amount);