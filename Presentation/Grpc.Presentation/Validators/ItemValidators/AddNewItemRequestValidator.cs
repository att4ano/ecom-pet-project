using FluentValidation;
using OrderItemGrpc;

namespace Grpc.Presentation.Validators.ItemValidators;

public class AddNewItemRequestValidator : AbstractValidator<AddNewItemRequest>
{
    public AddNewItemRequestValidator()
    {
        RuleFor(request => request.OrderId)
            .NotNull()
            .Must(ValidateGuid);
        RuleFor(request => request.ProductId)
            .NotNull()
            .Must(ValidateGuid);
        RuleFor(request => request.Amount)
            .GreaterThan(0);
    }
    
    private bool ValidateGuid(string guid)
    {
        return Guid.TryParse(guid, out _);
    } 
}