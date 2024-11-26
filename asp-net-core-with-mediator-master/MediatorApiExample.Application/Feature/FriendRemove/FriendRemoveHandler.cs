using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Application.Services;
using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.FriendRemove;

public class FriendRemoveHandler(Repository repository) : IRequestHandler<FriendRemoveCommand>
{
    public async Task Handle(FriendRemoveCommand request, CancellationToken cancellationToken)
    {
        await repository.RemoveAsync<FriendItem>(request.Id);
    }
}