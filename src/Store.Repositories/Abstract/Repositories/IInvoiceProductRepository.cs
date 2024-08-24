using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.InvoiceProduct;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IInvoiceProductRepository : IRepository<InvoiceProductEntity>
{
    public Task<IReadOnlyList<InvoiceWithProductsModel>> GetProductsByInvoiceIdAsync(Guid id,
        CancellationToken cancellationToken);

    public Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken);
}