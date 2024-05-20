namespace Application.Dto.ModelDto;

public record ProductDto(Guid Id, string Name, Guid CategoryId, decimal Price, string? Description);