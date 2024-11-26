using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorApiExample.Application.Feature.FriendCreate;

public record FriendCreatedNotification : INotification
{
    public FriendCreatedNotification(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}

public record EmailSendNotificationHandler : INotificationHandler<FriendCreatedNotification>
{
    public Task Handle(FriendCreatedNotification notification, CancellationToken cancellationToken)
    {
        // send email

        return Task.CompletedTask;
    }
}

public record SmsSendNotificationHandler : INotificationHandler<FriendCreatedNotification>
{
    public Task Handle(FriendCreatedNotification notification, CancellationToken cancellationToken)
    {
        // send sms

        return Task.CompletedTask;
    }
}