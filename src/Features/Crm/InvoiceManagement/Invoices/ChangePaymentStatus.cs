using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.Invoices;

internal sealed class ChangePaymentStatusCommandHandler: ICommandHandler<ChangePaymentStatusCommand>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public ChangePaymentStatusCommandHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<Unit> Handle(ChangePaymentStatusCommand command, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        invoice!.ChangePaymentStatus(command.PaymentStatus);
        _invoiceDomainRepository.Update(invoice);
        return Unit.Value;
    }
}
public record ChangePaymentStatusCommand(Guid Id, int PaymentStatus): ICommand;