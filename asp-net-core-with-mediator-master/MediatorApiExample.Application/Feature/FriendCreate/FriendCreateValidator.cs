using FluentValidation;

namespace MediatorApiExample.Application.Feature.FriendCreate;

public class FriendCreateValidator : AbstractValidator<FriendsCreateCommand>
{
    public FriendCreateValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
            .MinimumLength(5);
    }
}