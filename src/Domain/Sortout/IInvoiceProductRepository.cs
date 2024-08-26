using Forpost.Common.DataAccess;

namespace Forpost.Domain.Sortout;

public interface IInvoiceProductRepository : IRepository<InvoiceProduct>
{
    public Task<IReadOnlyList<InvoiceProduct>> GetProductsByInvoiceIdAsync(Guid id,
        CancellationToken cancellationToken);

    public Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken);
}