using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ManufacturingProcesses.Events;
using Forpost.Features.ProductCreating.ProductsDevelopments;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses.Handlers;

internal sealed class ManufacturingProcessLaunchedHandler: INotificationHandler<ManufacturingProcessLaunched>
{
    private readonly ISender _sender;

    public ManufacturingProcessLaunchedHandler(ISender sender)
    {
        _sender = sender;
    }

    public ValueTask Handle(ManufacturingProcessLaunched notification, CancellationToken cancellationToken)
    {
        var valueTask = _sender.Send(new BatchProductionInitializedCommand(notification.ManufacturingProcessId),
            cancellationToken);
        
        return ValueTask.CompletedTask;
    }
}