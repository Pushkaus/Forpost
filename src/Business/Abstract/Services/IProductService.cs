using Forpost.Business.Models.Products;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface IProductService : IBusinessService
{
    public Task<IReadOnlyList<ProductEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Guid> AddAsync(ProductCreateModel model, CancellationToken cancellationToken);
    public Task<ProductEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task UpdateAsync(ProductUpdateModel model, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}