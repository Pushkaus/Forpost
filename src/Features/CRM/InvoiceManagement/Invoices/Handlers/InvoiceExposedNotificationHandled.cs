using Forpost.Domain.CRM.InvoiceManagement.Events;
using Mediator;

namespace Forpost.Features.CRM.InvoiceManagement.Invoices.Handlers;

internal sealed class InvoiceExposedNotificationHandled: INotificationHandler<InvoiceCreated>
{
    public ValueTask Handle(InvoiceCreated notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Invoice Exposed");
        return ValueTask.CompletedTask;
    }
}