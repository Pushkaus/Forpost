using Forpost.Domain.Catalogs.Contractors;
using MediatR;

namespace Forpost.Features.Catalogs.Contractors;

internal sealed class ContractorAddedNotificationHandler : INotificationHandler<ContractorAdded>
{
    public Task Handle(ContractorAdded notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Handled");
        return Task.CompletedTask;
    }
}