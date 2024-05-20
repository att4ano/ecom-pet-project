using FluentValidation;
using OrderGrpc;

namespace Grpc.Presentation.Validators.OrderValidators;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(request => request.Items)
            .NotNull();
        RuleFor(request => request.Address)
            .NotNull();
    }
}