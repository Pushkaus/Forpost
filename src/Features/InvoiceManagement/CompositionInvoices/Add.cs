using Forpost.Domain.InvoiceManagement;
using Mediator;

namespace Forpost.Features.InvoiceManagement.CompositionInvoices;

internal sealed class AddCompositionInvoiceCommandHandler : ICommandHandler<AddCompositionInvoiceCommand>
{
    private readonly ICompositionInvoiceDomainRepository _compositionInvoiceDomainRepository;

    public AddCompositionInvoiceCommandHandler(ICompositionInvoiceDomainRepository compositionInvoiceDomainRepository)
    {
        _compositionInvoiceDomainRepository = compositionInvoiceDomainRepository;
    }

    public ValueTask<Unit> Handle(AddCompositionInvoiceCommand command, CancellationToken cancellationToken)
    {
        foreach (var product in command.CompletedProducts)
        {
            var compositionInvoice = new CompositionInvoice
            {
                InvoiceId = command.InvoiceId,
                ProductId = command.ProductId,
                CompletedProductId = product
            };
            _compositionInvoiceDomainRepository.Add(compositionInvoice);
        }
        return ValueTask.FromResult(Unit.Value);
    }
}

public record AddCompositionInvoiceCommand(
    Guid InvoiceId,
    Guid ProductId,
    IReadOnlyCollection<Guid> CompletedProducts) : ICommand;