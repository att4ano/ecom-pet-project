namespace Application.Dto.EndpointDto;

public record UpdateItemAmountDto(Guid OrderItemId, int NewAmount);