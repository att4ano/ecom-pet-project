using FluentValidation;
using ProductGrpc;

namespace Grpc.Presentation.Validators.ProductValidators;

public class UpdateProductPriceRequestValidator : AbstractValidator<UpdateProductPriceRequest>
{
    public UpdateProductPriceRequestValidator()
    {
        RuleFor(request => request.Price.Units)
            .NotNull()
            .GreaterThan(0);
        RuleFor(request => request.Price.Nanos)
            .NotNull()
            .GreaterThan(0)
            .LessThan(1_000_000);
        RuleFor(request => request.ProductId)
            .NotNull()
            .Must(ValidateGuid);
    }
    
    private bool ValidateGuid(string guid)
    {
        return Guid.TryParse(guid, out _);
    }
}