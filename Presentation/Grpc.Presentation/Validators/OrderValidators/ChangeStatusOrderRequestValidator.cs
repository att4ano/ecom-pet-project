using FluentValidation;
using OrderGrpc;

namespace Grpc.Presentation.Validators.OrderValidators;

public class ChangeStatusOrderRequestValidator : AbstractValidator<ChangeStatusOrderRequest>
{
    public ChangeStatusOrderRequestValidator()
    {
        RuleFor(request => request.OrderId)
            .NotNull();
    }
}