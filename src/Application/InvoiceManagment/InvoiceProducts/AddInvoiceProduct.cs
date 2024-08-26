using AutoMapper;
using Forpost.Domain.Sortout;
using MediatR;

namespace Forpost.Application.InvoiceManagment.InvoiceProducts;

internal sealed class AddInvoiceProductCommandHandler: IRequestHandler<AddInvoiceProductCommand>
{
    private readonly IInvoiceProductRepository _invoiceProductRepository;
    private readonly IMapper _mapper;
    
    public AddInvoiceProductCommandHandler(IInvoiceProductRepository invoiceProductRepository, IMapper mapper)
    {
        _invoiceProductRepository = invoiceProductRepository;
        _mapper = mapper;
    }

    public async Task Handle(AddInvoiceProductCommand request, CancellationToken cancellationToken)
    {
        var invoice = _mapper.Map<InvoiceProduct>(request);
        _invoiceProductRepository.Add(invoice);
    }
}

public record AddInvoiceProductCommand(Guid InvoiceId, Guid ProductId, int Quantity) : IRequest;
