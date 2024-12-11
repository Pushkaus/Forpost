using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.Products.ProductAttributes;

public interface IProductAttributeReadRepository : IApplicationReadRepository
{
    public Task<IReadOnlyCollection<ProductAttributeModel>> GetAllAttributesByProductIdAsync(Guid productId,
        CancellationToken cancellationToken);
}