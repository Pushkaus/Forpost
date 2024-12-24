using Forpost.Application.Contracts.CRM.InvoiceManagement.CompositionInvoices;
using Forpost.Application.Contracts.ProductCreating.CompletedProducts;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.CompositionInvoices;

internal sealed class GetRelevantProductsQueryHandler: 
    IQueryHandler<GetRelevantProductsQuery, IReadOnlyCollection<CompletedProductModel>>
{
    private readonly ICompositionInvoiceReadRepository _compositionInvoiceReadRepository;

    public GetRelevantProductsQueryHandler(ICompositionInvoiceReadRepository compositionInvoiceReadRepository)
    {
        _compositionInvoiceReadRepository = compositionInvoiceReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<CompletedProductModel>> 
        Handle(GetRelevantProductsQuery query, CancellationToken cancellationToken) 
        => await _compositionInvoiceReadRepository.GetRelevantProducts(query.InvoiceId, query.ProductId, cancellationToken);
}
public record GetRelevantProductsQuery(Guid InvoiceId, Guid ProductId): IQuery<IReadOnlyCollection<CompletedProductModel>>;