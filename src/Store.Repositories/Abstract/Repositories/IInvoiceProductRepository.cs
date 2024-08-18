using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IInvoiceProductRepository : IRepository<InvoiceProduct>
{
    public Task<IReadOnlyList<InvoiceWithProducts>> GetProductsByInvoiceIdAsync(Guid id,
        CancellationToken cancellationToken);

    public Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken);
}