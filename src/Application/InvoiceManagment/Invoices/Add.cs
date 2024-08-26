using AutoMapper;
using Forpost.Domain.InvoiceManagment;
using Forpost.Domain.Sortout;
using MediatR;

namespace Forpost.Application.InvoiceManagment.Invoices;

internal sealed class AddInvoiceCommandHandler: IRequestHandler<AddInvoiceCommand, Guid>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IMapper _mapper;

    public AddInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(AddInvoiceCommand command, CancellationToken cancellationToken)
    {
        var invoice = _mapper.Map<Invoice>(command);
        
        invoice.InitialAdd();
        
        return Task.FromResult(_invoiceRepository.Add(invoice));
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