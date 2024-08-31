using Forpost.Domain.Catalogs.Contractors;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

internal sealed class ContractorAddedNotificationHandler : INotificationHandler<ContractorAdded>
{
    public ValueTask Handle(ContractorAdded notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Handled");
        return ValueTask.CompletedTask;
    }
}