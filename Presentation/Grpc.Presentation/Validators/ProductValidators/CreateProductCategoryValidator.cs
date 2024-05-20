using FluentValidation;
using ProductGrpc;

namespace Grpc.Presentation.Validators.ProductValidators;

public class CreateProductCategoryValidator : AbstractValidator<CreateProductCategoryRequest>
{
    public CreateProductCategoryValidator()
    {
        RuleFor(request => request.Name)
            .NotNull();
    }
}