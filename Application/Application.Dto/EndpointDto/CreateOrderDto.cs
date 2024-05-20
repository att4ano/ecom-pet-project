namespace Application.Dto.ModelDto;

public record CreateOrderDto(Dictionary<Guid, int> Items, string Address, string Description);