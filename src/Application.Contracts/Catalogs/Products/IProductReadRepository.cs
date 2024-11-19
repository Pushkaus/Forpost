using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.Products;

public interface IProductReadRepository: IApplicationReadRepository
{
    public Task<ProductModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<EntityPagedResult<ProductModel>> GetAllAsync(ProductFilter filter, CancellationToken cancellationToken);
}