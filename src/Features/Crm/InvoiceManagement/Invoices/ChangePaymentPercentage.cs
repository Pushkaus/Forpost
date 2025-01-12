using Forpost.Domain.Crm.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.Invoices;

internal sealed class ChangePaymentPercentageCommandHandler : ICommandHandler<ChangePaymentPercentageCommand>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public ChangePaymentPercentageCommandHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<Unit> Handle(ChangePaymentPercentageCommand command, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        invoice!.SetPaymentPercentage(command.PaymentPercentage);
        _invoiceDomainRepository.Update(invoice);
        return Unit.Value;
    }
}

public record ChangePaymentPercentageCommand(Guid Id, decimal PaymentPercentage) : ICommand;