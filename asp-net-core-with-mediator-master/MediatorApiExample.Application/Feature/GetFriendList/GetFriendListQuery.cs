using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.GetFriendList;
public record GetFriendListQuery : IRequest<FriendItem[]>;