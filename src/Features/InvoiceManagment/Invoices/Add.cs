using AutoMapper;
using Forpost.Domain.InvoiceManagement;
using Mediator;

namespace Forpost.Features.InvoiceManagment.Invoices;

internal sealed class AddInvoiceCommandHandler: ICommandHandler<AddInvoiceCommand, Guid>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;
    private readonly IMapper _mapper;

    public AddInvoiceCommandHandler(IInvoiceDomainRepository invoiceDomainRepository, IMapper mapper)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
        _mapper = mapper;
    }

    public ValueTask<Guid> Handle(AddInvoiceCommand command, CancellationToken cancellationToken)
    {
        
        var invoiceId = _invoiceDomainRepository.Add(Invoice.Expose(command.Number,
            command.ContragentId,
            command.Description,
            command.PaymentPercentage,
            command.DaysShipment));
        
        return ValueTask.FromResult(invoiceId);
    }
}
public record AddInvoiceCommand: ICommand<Guid>
{
    public string Number { get; set; } = default!;
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int DaysShipment { get; set; }
    public int PaymentPercentage { get; set; }
}