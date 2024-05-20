using Domain.Status;

namespace Application.Dto;

public record OrderFilterDto(DateTime? CreationTime, OrderStatus? OrderStatus);