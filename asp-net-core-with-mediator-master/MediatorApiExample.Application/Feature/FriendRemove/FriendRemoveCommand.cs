using System;
using MediatR;

namespace MediatorApiExample.Application.Feature.FriendRemove;

public record FriendRemoveCommand(Guid Id) : IRequest;
