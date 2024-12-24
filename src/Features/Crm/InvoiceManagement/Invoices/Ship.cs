using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.Invoices;

internal sealed class ShipInvoiceCommandHandler: ICommandHandler<ShipInvoiceCommand>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public ShipInvoiceCommandHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<Unit> Handle(ShipInvoiceCommand command, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        invoice!.SetShipmentDate(command.ShipDate);
        _invoiceDomainRepository.Update(invoice);
        return Unit.Value;
    }
}
public record ShipInvoiceCommand(Guid Id, DateTimeOffset ShipDate): ICommand;