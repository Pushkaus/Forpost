using Forpost.Domain.SortOut;
using Mediator;

namespace Forpost.Features.InvoiceManagment.InvoiceProducts;

internal sealed class GetProductsFromInvoiceQueryHandler: IQueryHandler<GetCompositionInvoiceQuery, IReadOnlyCollection<InvoiceProduct>>
{
    private readonly IInvoiceProductDomainRepository _invoiceProductDomainRepository;
    
    public GetProductsFromInvoiceQueryHandler(IInvoiceProductDomainRepository invoiceProductDomainRepository)
    {
        _invoiceProductDomainRepository = invoiceProductDomainRepository;
    }

    public async ValueTask<IReadOnlyCollection<InvoiceProduct>> Handle
        (GetCompositionInvoiceQuery request, CancellationToken cancellationToken) 
        => await _invoiceProductDomainRepository.GetProductsByInvoiceIdAsync(request.InvoiceId, cancellationToken);
}

public record GetCompositionInvoiceQuery(Guid InvoiceId) : IQuery<IReadOnlyCollection<InvoiceProduct>>; 