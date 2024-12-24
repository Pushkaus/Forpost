using Forpost.Common;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.Invoices;

internal sealed class SetClosingDateInvoiceCommandHandler: ICommandHandler<SetClosingDateInvoiceCommand>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public SetClosingDateInvoiceCommandHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<Unit> Handle(SetClosingDateInvoiceCommand command, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        if (invoice == null) throw ForpostErrors.NotFound<Invoice>(command.Id);
        
        invoice.SetClosingDate(command.ClosingDate);
        
        _invoiceDomainRepository.Update(invoice);
        
        return Unit.Value;
    }
}
public record SetClosingDateInvoiceCommand(Guid Id, DateTimeOffset ClosingDate): ICommand;