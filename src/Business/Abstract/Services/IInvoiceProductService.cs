using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IInvoiceProductService: IBusinessService
{
    public Task Add(InvoiceProductCreateModel model);
    public Task<IReadOnlyList<InvoiceProduct?>> GetProductsById(Guid id);
}