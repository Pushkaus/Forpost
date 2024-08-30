using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Primitives.EventHandling;

namespace Forpost.Features.Catalogs.Contractors;

public sealed class ContractorAddedNotificationHandler : IDomainEventHandler<ContractorAdded>
{
    public Task Handle(ContractorAdded domainEvent, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Handled");
        return Task.CompletedTask;
    }
}