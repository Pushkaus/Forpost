using Forpost.Common.ApplicationNotifications;
using Forpost.Domain.Crm.InvoiceManagement.Events;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.Invoices.Handlers;

internal sealed class InvoiceCreatedNotificationHandler: INotificationHandler<InvoiceCreated>, IApplicationNotification
{
    public ValueTask Handle(InvoiceCreated notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Invoice Exposed");
        return ValueTask.CompletedTask;
    }
}