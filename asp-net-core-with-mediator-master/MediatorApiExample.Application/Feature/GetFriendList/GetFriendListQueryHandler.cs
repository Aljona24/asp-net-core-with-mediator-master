using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Application.Services;
using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.GetFriendList;

public class GetFriendListQueryHandler(Repository repository) : IRequestHandler<GetFriendListQuery, FriendItem[]>
{
    public async Task<FriendItem[]> Handle(GetFriendListQuery request, CancellationToken cancellationToken)
    {
        var items = await repository.FindAsync<FriendItem>();

        return items.ToArray();
    }
}