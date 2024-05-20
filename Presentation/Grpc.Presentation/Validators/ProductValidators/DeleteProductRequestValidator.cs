using FluentValidation;
using ProductGrpc;

namespace Grpc.Presentation.Validators.ProductValidators;

public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
{
    public DeleteProductRequestValidator()
    {
        RuleFor(request => request.ProductId)
            .NotNull()
            .Must(ValidateGuid);
    }
    
    private bool ValidateGuid(string guid)
    {
        return Guid.TryParse(guid, out _);
    }
}