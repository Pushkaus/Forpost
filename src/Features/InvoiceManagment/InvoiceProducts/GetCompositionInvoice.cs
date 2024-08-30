using Forpost.Domain.SortOut;
using MediatR;

namespace Forpost.Features.InvoiceManagment.InvoiceProducts;

internal sealed class GetProductsFromInvoice: IRequestHandler<GetCompositionInvoiceQuery, IReadOnlyCollection<InvoiceProduct>>
{
    private readonly IInvoiceProductDomainRepository _invoiceProductDomainRepository;
    
    public GetProductsFromInvoice(IInvoiceProductDomainRepository invoiceProductDomainRepository)
    {
        _invoiceProductDomainRepository = invoiceProductDomainRepository;
    }

    public async Task<IReadOnlyCollection<InvoiceProduct>> Handle
        (GetCompositionInvoiceQuery request, CancellationToken cancellationToken) 
        => await _invoiceProductDomainRepository.GetProductsByInvoiceIdAsync(request.InvoiceId, cancellationToken);
}

public record GetCompositionInvoiceQuery(Guid InvoiceId) : IRequest<IReadOnlyCollection<InvoiceProduct>>; 