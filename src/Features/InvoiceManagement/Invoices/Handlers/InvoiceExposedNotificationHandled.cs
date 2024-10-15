using Forpost.Domain.CRM.InvoiceManagement.Events;
using Mediator;

namespace Forpost.Features.InvoiceManagement.Invoices.Handlers;

internal sealed class InvoiceExposedNotificationHandled: INotificationHandler<InvoiceExposed>
{
    public ValueTask Handle(InvoiceExposed notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Invoice Exposed");
        return ValueTask.CompletedTask;
    }
}