using Forpost.Domain.InvoiceManagement;
using Forpost.Domain.InvoiceManagement.Events;
using Mediator;

namespace Forpost.Features.InvoiceManagment.Invoices;

internal sealed class InvoiceExposedNotificationHandled: INotificationHandler<InvoiceExposed>
{
    public ValueTask Handle(InvoiceExposed notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Invoice Exposed");
        return ValueTask.CompletedTask;
    }
}