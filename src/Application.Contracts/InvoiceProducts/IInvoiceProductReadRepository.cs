using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.InvoiceProducts;

public interface IInvoiceProductReadRepository: IApplicationReadRepository
{
    public Task<IReadOnlyList<InvoiceWithProducts>>
        GetProductsByInvoiceIdAsync(Guid id, CancellationToken cancellationToken);
}