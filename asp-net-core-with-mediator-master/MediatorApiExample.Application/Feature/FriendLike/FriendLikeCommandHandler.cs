using MediatorApiExample.Application.Services;
using MediatorApiExample.Core.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorApiExample.Application.Feature.FriendLike;

public class FriendLikeCommandHandler(Repository repository) : IRequestHandler<FriendLikeCommand>
{
    public async Task Handle(FriendLikeCommand request, CancellationToken cancellationToken)
    {
        var item = await repository.FindByIdAsync<FriendItem>(request.Id);
        if (item == null) throw new ApplicationException("Friend not found");

        item.ToggleLike();

        await repository.SaveAsync(item);
    }
}