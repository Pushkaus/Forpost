using Forpost.Common;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.InvoiceProducts;

internal sealed class ChangeQuantityCommandHandler: ICommandHandler<ChangeQuantityCommand>
{
    private readonly IInvoiceProductDomainRepository _invoiceProductDomainRepository;

    public ChangeQuantityCommandHandler(IInvoiceProductDomainRepository invoiceProductDomainRepository)
    {
        _invoiceProductDomainRepository = invoiceProductDomainRepository;
    }

    public async ValueTask<Unit> Handle(ChangeQuantityCommand command, CancellationToken cancellationToken)
    {
        var invoiceProduct = await _invoiceProductDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        if (invoiceProduct == null) throw ForpostErrors.NotFound<InvoiceProduct>(command.Id);
        invoiceProduct.ChangeQuantity(command.Quantity);
        _invoiceProductDomainRepository.Update(invoiceProduct);
        return Unit.Value;
    }
}
public record ChangeQuantityCommand(Guid Id, int Quantity): ICommand;