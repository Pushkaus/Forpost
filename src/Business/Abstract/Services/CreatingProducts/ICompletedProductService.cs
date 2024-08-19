using Forpost.Business.Models.CompletedProduct;
using Forpost.Store.Entities;
using Forpost.Store.Entities.ProductCreating;

namespace Forpost.Business.Abstract.Services.CreatingProducts;

public interface ICompletedProductService: IBusinessService
{
    public Task<Guid> AddAsync(CompletedProductCreateModel model, CancellationToken cancellationToken);
    public Task<CompletedProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<CompletedProduct>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}