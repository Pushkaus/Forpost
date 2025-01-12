using Forpost.Common;
using Forpost.Domain.Crm.InvoiceManagement;
using Forpost.Domain.Crm.InvoiceManagement.Contracts;
using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Domain.ProductCreating.ManufacturingOrders.Contracts;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingOrders;

internal sealed class CreateManufacturingOrderCommandHandler : ICommandHandler<CreateManufacturingOrderCommand, Guid>
{
    private readonly IManufacturingOrderDomainRepository _manufacturingOrderDomainRepository;
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public CreateManufacturingOrderCommandHandler(
        IManufacturingOrderDomainRepository manufacturingOrderDomainRepository,
        IInvoiceDomainRepository invoiceDomainRepository)
    {
        _manufacturingOrderDomainRepository = manufacturingOrderDomainRepository;
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<Guid> Handle(CreateManufacturingOrderCommand command, CancellationToken cancellationToken)
    {
        var manufacturingOrder = ManufacturingOrder.Create(command.InvoiceId);
        var invoice = await _invoiceDomainRepository.GetByIdAsync(command.InvoiceId, cancellationToken);
        if (invoice == null) throw ForpostErrors.NotFound<Invoice>(command.InvoiceId);
        invoice.SentToManufacturingOrder();
        return _manufacturingOrderDomainRepository.Add(manufacturingOrder);
    }
}

public record CreateManufacturingOrderCommand(Guid InvoiceId) : ICommand<Guid>;