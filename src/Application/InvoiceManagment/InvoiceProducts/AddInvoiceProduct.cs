using AutoMapper;
using Forpost.Domain.SortOut;
using MediatR;

namespace Forpost.Application.InvoiceManagment.InvoiceProducts;

internal sealed class AddInvoiceProductCommandHandler: IRequestHandler<AddInvoiceProductCommand>
{
    private readonly IInvoiceProductDomainRepository _invoiceProductDomainRepository;
    private readonly IMapper _mapper;
    
    public AddInvoiceProductCommandHandler(IInvoiceProductDomainRepository invoiceProductDomainRepository, IMapper mapper)
    {
        _invoiceProductDomainRepository = invoiceProductDomainRepository;
        _mapper = mapper;
    }

    public async Task Handle(AddInvoiceProductCommand request, CancellationToken cancellationToken)
    {
        var invoice = _mapper.Map<InvoiceProduct>(request);
        _invoiceProductDomainRepository.Add(invoice);
    }
}

public record AddInvoiceProductCommand(Guid InvoiceId, Guid ProductId, int Quantity) : IRequest;
