using System;
using FluentValidation;

namespace MediatorApiExample.Application.Feature.FriendRemove;

public class FriendRemoveCommandValidator : AbstractValidator<FriendRemoveCommand>
{
    public FriendRemoveCommandValidator()
    {
        RuleFor(s => s.Id).Must((id) => id != Guid.Empty);
    }
}