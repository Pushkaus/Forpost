using Forpost.Application.Contracts.ProductCreating.CompletedProducts;
using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.InvoiceManagment.CompositionInvoices;

public interface ICompositionInvoiceReadRepository : IApplicationReadRepository
{
    public Task<IReadOnlyList<CompletedProductModel>>
        GetRelevantProducts(Guid invoiceId, Guid productId, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<CompositionInvoiceModel>> GetCompositionInvoice(Guid invoiceId,
        CancellationToken cancellationToken);
}