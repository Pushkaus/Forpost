using AutoMapper;
using Forpost.Domain.InvoiceManagement;
using MediatR;

namespace Forpost.Application.InvoiceManagment.Invoices;

internal sealed class AddInvoiceCommandHandler: IRequestHandler<AddInvoiceCommand, Guid>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;
    private readonly IMapper _mapper;

    public AddInvoiceCommandHandler(IInvoiceDomainRepository invoiceDomainRepository, IMapper mapper)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(AddInvoiceCommand command, CancellationToken cancellationToken)
    {
        var invoice = _mapper.Map<Invoice>(command);
        
        invoice.InitialAdd();
        
        return Task.FromResult(_invoiceDomainRepository.Add(invoice));
    }
}
public record AddInvoiceCommand: IRequest<Guid>
{
    public string Number { get; set; } = default!;
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int? DaysShipment { get; set; }
    public int? PaymentPercentage { get; set; }
}