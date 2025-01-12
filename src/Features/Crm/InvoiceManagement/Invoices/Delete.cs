using Forpost.Domain.Crm.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.Invoices;

internal sealed class DeleteInvoiceCommandHandler: ICommandHandler<DeleteInvoiceCommand>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public DeleteInvoiceCommandHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteInvoiceCommand command, CancellationToken cancellationToken)
    {
        _invoiceDomainRepository.DeleteById(command.Id);
        return Unit.ValueTask;
    }
}
public record DeleteInvoiceCommand(Guid Id): ICommand;