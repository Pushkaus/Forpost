using Forpost.Business.Catalogs.Products.Commands;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.Products;

public interface IProductService : IBusinessService
{
    public Task<IReadOnlyList<ProductEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Guid> AddAsync(ProductCreateCommand model, CancellationToken cancellationToken);
    public Task<ProductEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task UpdateAsync(ProductUpdateCommand model, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}