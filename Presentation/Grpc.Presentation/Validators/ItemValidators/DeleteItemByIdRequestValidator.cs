using FluentValidation;
using OrderItemGrpc;

namespace Grpc.Presentation.Validators.ItemValidators;

public class DeleteItemByIdRequestValidator : AbstractValidator<DeleteItemByIdRequest>
{
    public DeleteItemByIdRequestValidator()
    {
        RuleFor(request => request.ItemId)
            .NotNull()
            .Must(ValidateGuid);
    }

    private bool ValidateGuid(string guid)
    {
        return Guid.TryParse(guid, out _);
    }
}