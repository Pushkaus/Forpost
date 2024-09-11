using Forpost.Application.Contracts.InvoiceManagment.CompositionInvoice;
using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.InvoiceManagment.CompositionInvoices;

public interface ICompositionInvoiceReadRepository: IApplicationReadRepository
{
    public Task<IReadOnlyList<CompletedProductModel>>
        GetRelevantProducts(Guid invoiceId, Guid productId, CancellationToken cancellationToken);
}