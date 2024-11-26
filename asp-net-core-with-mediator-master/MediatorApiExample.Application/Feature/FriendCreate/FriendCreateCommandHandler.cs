using System;
using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Application.Services;
using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.FriendCreate;

public class FriendCreateCommandHandler(IMediator mediator, Repository repository)
    : IRequestHandler<FriendsCreateCommand, Guid>
{
    public async Task<Guid> Handle(FriendsCreateCommand request, CancellationToken cancellationToken)
    {
        var friend = new FriendItem(Guid.NewGuid(), request.Name, false);

        await repository.SaveAsync(friend);

        await mediator.Publish(new FriendCreatedNotification(friend.Id), cancellationToken);

        return friend.Id;
    }
}