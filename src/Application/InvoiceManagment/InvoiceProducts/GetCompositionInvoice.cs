using Forpost.Domain.Sortout;
using MediatR;

namespace Forpost.Application.InvoiceManagment.InvoiceProducts;

internal sealed class GetProductsFromInvoice: IRequestHandler<GetCompositionInvoiceQuery, IReadOnlyCollection<InvoiceProduct>>
{
    private readonly IInvoiceProductRepository _invoiceProductRepository;
    
    public GetProductsFromInvoice(IInvoiceProductRepository invoiceProductRepository)
    {
        _invoiceProductRepository = invoiceProductRepository;
    }

    public async Task<IReadOnlyCollection<InvoiceProduct>> Handle
        (GetCompositionInvoiceQuery request, CancellationToken cancellationToken) 
        => await _invoiceProductRepository.GetProductsByInvoiceIdAsync(request.InvoiceId, cancellationToken);
}

public record GetCompositionInvoiceQuery(Guid InvoiceId) : IRequest<IReadOnlyCollection<InvoiceProduct>>; 