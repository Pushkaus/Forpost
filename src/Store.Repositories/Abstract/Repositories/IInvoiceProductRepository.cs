using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IInvoiceProductRepository: IRepository<InvoiceProduct>
{
    public Task<IReadOnlyList<InvoiceProduct?>> GetProductsById(Guid id);

}