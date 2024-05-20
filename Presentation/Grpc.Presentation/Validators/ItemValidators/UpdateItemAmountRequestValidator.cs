using FluentValidation;
using OrderItemGrpc;

namespace Grpc.Presentation.Validators.ItemValidators;

public class UpdateItemAmountRequestValidator : AbstractValidator<UpdateItemAmountRequest>
{
    public UpdateItemAmountRequestValidator()
    {
        RuleFor(request => request.Amount)
            .NotNull()
            .GreaterThan(0);
        RuleFor(request => request.ItemId)
            .NotNull()
            .Must(ValidateGuid);
    }
    
    private bool ValidateGuid(string guid)
    {
        return Guid.TryParse(guid, out _);
    } 
}