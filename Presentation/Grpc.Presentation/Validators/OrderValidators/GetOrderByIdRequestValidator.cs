using FluentValidation;
using OrderGrpc;

namespace Grpc.Presentation.Validators.OrderValidators;

public class GetOrderByIdRequestValidator : AbstractValidator<GetOrderByIdRequest>
{
    public GetOrderByIdRequestValidator()
    {
        RuleFor(request => request.OrderId)
            .NotNull()
            .Must(GuidValidate);
    }

    private bool GuidValidate(string guid)
    {
        return Guid.TryParse(guid, out _);
    }
}