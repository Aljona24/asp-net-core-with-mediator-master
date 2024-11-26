using MediatR;
using System;

namespace MediatorApiExample.Application.Feature.FriendLike;

public record FriendLikeCommand(Guid Id) : IRequest;