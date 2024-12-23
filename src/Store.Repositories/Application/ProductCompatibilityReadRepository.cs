using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Forpost.Application.Contracts.Catalogs.Products.ProductCompatibilities;

namespace Forpost.Store.Repositories.Application;

internal sealed class ProductCompatibilityReadRepository : IProductCompatibilityReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ProductCompatibilityReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<ProductCompatibilityModel>> GetAllProductCompatibilityAsync(Guid productId,
        CancellationToken cancellationToken)
    {
        var productCompatibility = await _dbContext.ProductCompatibilities
            .Where(x => x.ProductId == productId)
            .Join(_dbContext.Products,
                pc => pc.ParentProductId,
                p => p.Id,
                (pc, parentProduct) => new ProductCompatibilityModel
                {
                    Id = pc.Id, 
                    ProductId = pc.ProductId,
                    ProductName = _dbContext.Products.Where(p => p.Id == pc.ProductId).Select(p => p.Name).FirstOrDefault() ?? string.Empty,
                    ParentProductId = parentProduct.Id,
                    ParentProductName = parentProduct.Name
                })
            .ToListAsync(cancellationToken);

        return productCompatibility;
    }
}