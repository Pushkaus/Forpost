using Forpost.Application.Contracts.InvoiceProducts;
using Forpost.Domain.SortOut;
using Mediator;

namespace Forpost.Features.InvoiceManagment.InvoiceProducts;

internal sealed class GetProductsFromInvoiceQueryHandler: IQueryHandler<GetCompositionInvoiceQuery, IReadOnlyCollection<InvoiceWithProducts>>
{
    private readonly IInvoiceProductReadRepository _invoiceProductReadRepository;    
    public GetProductsFromInvoiceQueryHandler(IInvoiceProductReadRepository invoiceProductReadRepository)
    {
        _invoiceProductReadRepository = invoiceProductReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<InvoiceWithProducts>> Handle
        (GetCompositionInvoiceQuery request, CancellationToken cancellationToken) 
        => await _invoiceProductReadRepository.GetProductsByInvoiceIdAsync(request.InvoiceId, cancellationToken);
}

public record GetCompositionInvoiceQuery(Guid InvoiceId) : IQuery<IReadOnlyCollection<InvoiceWithProducts>>; 