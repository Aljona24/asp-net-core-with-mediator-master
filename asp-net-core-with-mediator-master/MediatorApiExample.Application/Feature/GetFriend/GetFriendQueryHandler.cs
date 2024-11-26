using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Application.Services;
using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.GetFriend;

public class GetFriendQueryHandler(Repository repository) : IRequestHandler<GetFriendQuery, FriendItem>
{
    public async Task<FriendItem> Handle(GetFriendQuery request, CancellationToken cancellationToken)
    {
        var items = await repository.FindByIdAsync<FriendItem>(request.Id);

        return items;
    }
}