using System;
using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.GetFriend;

public record GetFriendQuery(Guid Id) : IRequest<FriendItem>;