using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.CRM.InvoiceManagement.InvoiceProducts;

internal sealed class DeleteInvoiceProductCommandHandler: ICommandHandler<DeleteInvoiceProductCommand>
{
    private readonly IInvoiceProductDomainRepository _invoiceProductDomainRepository;

    public DeleteInvoiceProductCommandHandler(IInvoiceProductDomainRepository invoiceProductDomainRepository)
    {
        _invoiceProductDomainRepository = invoiceProductDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteInvoiceProductCommand command, CancellationToken cancellationToken)
    {
        _invoiceProductDomainRepository.DeleteById(command.Id);
        return Unit.ValueTask;
    }
}
public record DeleteInvoiceProductCommand(Guid Id): ICommand;