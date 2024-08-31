using AutoMapper;
using Forpost.Domain.SortOut;
using Mediator;

namespace Forpost.Features.InvoiceManagment.InvoiceProducts;

internal sealed class AddInvoiceProductCommandHandler: ICommandHandler<AddInvoiceProductCommand>
{
    private readonly IInvoiceProductDomainRepository _invoiceProductDomainRepository;
    private readonly IMapper _mapper;
    
    public AddInvoiceProductCommandHandler(IInvoiceProductDomainRepository invoiceProductDomainRepository, IMapper mapper)
    {
        _invoiceProductDomainRepository = invoiceProductDomainRepository;
        _mapper = mapper;
    }

    public async ValueTask<Unit> Handle(AddInvoiceProductCommand request, CancellationToken cancellationToken)
    {
        var invoice = _mapper.Map<InvoiceProduct>(request);
        _invoiceProductDomainRepository.Add(invoice);
        return await ValueTask.FromResult(Unit.Value);
    }
}

public record AddInvoiceProductCommand(Guid InvoiceId, Guid ProductId, int Quantity) : ICommand;
