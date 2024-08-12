using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IInvoiceProductRepository: IRepository<InvoiceProduct>
{
    public Task<IReadOnlyList<InvoiceWithProducts>> GetProductsByInvoiceId(Guid id);
    public Task DeleteByProductId(Guid id);

}