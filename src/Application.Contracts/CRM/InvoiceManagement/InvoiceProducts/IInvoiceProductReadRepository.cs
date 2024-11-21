using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.CRM.InvoiceManagement.InvoiceProducts;

public interface IInvoiceProductReadRepository: IApplicationReadRepository
{
    public Task<IReadOnlyList<InvoiceWithProductsModel>>
        GetProductsByInvoiceIdAsync(Guid id, CancellationToken cancellationToken);
}