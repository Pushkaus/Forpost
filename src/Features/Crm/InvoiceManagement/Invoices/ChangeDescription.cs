using Forpost.Common;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.Invoices;

internal sealed class ChangeDescriptionInvoiceCommandHandler: ICommandHandler<ChangeDescriptionInvoiceCommand>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public ChangeDescriptionInvoiceCommandHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<Unit> Handle(ChangeDescriptionInvoiceCommand command, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByIdAsync(command.InvoiceId, cancellationToken);
        if (invoice == null) throw ForpostErrors.NotFound<Invoice>(command.InvoiceId);
        
        invoice.ChangeDescription(command.Description);
        
        _invoiceDomainRepository.Update(invoice);
        return Unit.Value;
    }
}
public record ChangeDescriptionInvoiceCommand(Guid InvoiceId, string Description): ICommand;