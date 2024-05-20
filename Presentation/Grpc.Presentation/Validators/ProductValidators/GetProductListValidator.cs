using FluentValidation;
using ProductGrpc;

namespace Grpc.Presentation.Validators.ProductValidators;

public class GetProductListValidator : AbstractValidator<ProductFilter>
{
    public GetProductListValidator()
    {
    }
}