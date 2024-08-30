using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Primitives.DomainAbstractions;
using MediatR;

namespace Forpost.Application.Catalogs.Contractors;

internal sealed class ContractorAddedNotificationHandler : INotificationHandler<DomainEventNotification<ContractorAdded>>
{
    public Task Handle(DomainEventNotification<ContractorAdded> notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Handled");

        return Task.CompletedTask;
    }
}

public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : IDomainEvent
{
    public TDomainEvent DomainEvent { get; }
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }
}