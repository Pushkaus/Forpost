using AutoMapper;
using Forpost.Domain.CRM.InvoiceManagement;
using Mediator;

namespace Forpost.Features.InvoiceManagement.Invoices;

internal sealed class AddInvoiceCommandHandler: ICommandHandler<AddInvoiceCommand, Guid>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;
    private readonly IInvoiceProductDomainRepository _invoiceProductDomainRepository;
    private readonly IMapper _mapper;

    public AddInvoiceCommandHandler(IInvoiceDomainRepository invoiceDomainRepository, IMapper mapper, IInvoiceProductDomainRepository invoiceProductDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
        _mapper = mapper;
        _invoiceProductDomainRepository = invoiceProductDomainRepository;
    }

    public ValueTask<Guid> Handle(AddInvoiceCommand command, CancellationToken cancellationToken)
    {
        
        var invoiceId = _invoiceDomainRepository.Add(Invoice.Expose(
            command.Number,
            command.ContractorId,
            command.Description,
            command.PaymentPercentage,
            command.DaysShipment));
        
        foreach (var product in command.Products)
        {
            product.Id = Guid.NewGuid();
            product.InvoiceId = invoiceId;
            _invoiceProductDomainRepository.Add(product);
        }
        return ValueTask.FromResult(invoiceId);
    }
}
public record AddInvoiceCommand: ICommand<Guid>
{
    public string Number { get; set; } = default!;
    public Guid ContractorId { get; set; }
    public string? Description { get; set; }
    public int DaysShipment { get; set; }
    public decimal PaymentPercentage { get; set; }
    public IReadOnlyList<InvoiceProduct>? Products { get; set; }
}