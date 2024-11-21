using Forpost.Domain.ChangeLogs.Contracts;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.CRM.InvoiceManagement.Invoices;

internal sealed class ChangePaymentPercentageCommandHandler : ICommandHandler<ChangePaymentPercentageCommand>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;
    private readonly IChangeLogDomainRepository _changeLogDomainRepository;

    public ChangePaymentPercentageCommandHandler(IInvoiceDomainRepository invoiceDomainRepository,
        IChangeLogDomainRepository changeLogDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
        _changeLogDomainRepository = changeLogDomainRepository;
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