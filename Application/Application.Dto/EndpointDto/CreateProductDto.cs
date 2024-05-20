namespace Application.Dto.EndpointDto;

public record CreateProductDto(string Name, Guid CategoryId, decimal Price, string? Description);