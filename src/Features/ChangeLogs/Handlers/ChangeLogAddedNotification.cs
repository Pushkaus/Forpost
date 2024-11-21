using Forpost.Domain.ChangeLogs;
using Forpost.Domain.ChangeLogs.Contracts;
using Forpost.Domain.ChangeLogs.Events;
using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.ChangeLogs.Handlers;

internal sealed class ChangeLogAddedNotification : INotificationHandler<ChangeLogAdded>
{
    private readonly IChangeLogDomainRepository _domainRepository;

    public ChangeLogAddedNotification(IChangeLogDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public ValueTask Handle(ChangeLogAdded notification, CancellationToken cancellationToken)
    {
        var changeLog = ChangeLog.Create(notification.ChangeLog.EntityId, notification.ChangeLog.PropertyName,
            notification.ChangeLog.OldValue, notification.ChangeLog.NewValue);
        _domainRepository.Add(changeLog);
        return ValueTask.CompletedTask;
    }
}