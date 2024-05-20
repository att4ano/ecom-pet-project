using FluentValidation;
using ProductGrpc;

namespace Grpc.Presentation.Validators.ProductValidators;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(request => request.Name)
            .NotNull();
        RuleFor(request => request.CategoryId)
            .NotNull()
            .Must(ValidateGuid);
        RuleFor(request => request.Price)
            .NotNull();
    }
    
    private bool ValidateGuid(string guid)
    {
        return Guid.TryParse(guid, out _);
    }
}