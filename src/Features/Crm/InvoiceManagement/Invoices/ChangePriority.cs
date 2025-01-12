using Forpost.Domain.Crm.InvoiceManagement.Contracts;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.Invoices;

internal sealed class ChangePriorityCommandHandler: ICommandHandler<ChangePriorityCommand>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public ChangePriorityCommandHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<Unit> Handle(ChangePriorityCommand command, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        invoice!.ChangePriority(command.Priority);
        _invoiceDomainRepository.Update(invoice);
        return Unit.Value;
    }
}
public record ChangePriorityCommand(Guid Id, int Priority): ICommand;