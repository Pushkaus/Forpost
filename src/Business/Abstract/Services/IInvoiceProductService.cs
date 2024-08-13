using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IInvoiceProductService: IBusinessService
{
    public Task AddAsync(InvoiceProductCreateModel model, CancellationToken cancellationToken);
    public Task<IReadOnlyList<InvoiceProductModel?>>
        GetProductsByInvoiceIdAsync(Guid id, CancellationToken cancellationToken);
    public Task UpdateAsync(InvoiceProductCreateModel model, CancellationToken cancellationToken);
    public Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken);
}