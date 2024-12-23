using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.Products.ProductCompatibilities;

public interface IProductCompatibilityReadRepository : IApplicationReadRepository
{
    public Task<IReadOnlyCollection<ProductCompatibilityModel>> GetAllProductCompatibilityAsync(Guid productId,
        CancellationToken cancellationToken);
}