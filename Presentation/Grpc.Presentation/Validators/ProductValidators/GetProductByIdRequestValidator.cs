using FluentValidation;
using ProductGrpc;

namespace Grpc.Presentation.Validators.ProductValidators;

public class GetProductByIdRequestValidator : AbstractValidator<GetProductByIdRequest>
{
    public GetProductByIdRequestValidator()
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