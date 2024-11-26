using MediatR;
using System;

namespace MediatorApiExample.Application.Feature.FriendCreate;

public record FriendsCreateCommand(string Name) : IRequest<Guid>;