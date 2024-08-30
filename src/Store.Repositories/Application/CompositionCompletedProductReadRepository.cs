using Forpost.Application.Contracts.CompositionCompletedProducts;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class CompositionCompletedProductReadRepository: ICompositionCompletedProductReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public CompositionCompletedProductReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<CompositionCompletedProductWithSummary>> 
        GetCompositionCompletedProductWithSummaryAsync(Guid completedProductId, CancellationToken cancellationToken)
    {
        return await _dbContext.CompositionCompletedProducts.Where(c => c.CompletedProductId == completedProductId)
            .Join(_dbContext.CompletedProducts,
                completedItem => completedItem.CompletedItemId,
                item => item.Id,
                (completedItem, item) => new { completedItem, item })
            .Join(_dbContext.ProductDevelopments,
                combined => combined.item.ProductDevelopmentId,
                productDevelopment => productDevelopment.Id,
                (combined, productDevelopment) => new { combined, productDevelopment })
            .Join(_dbContext.Products,
                combined => combined.combined.item.ProductId,
                product => product.Id,
                (combined, product) => new CompositionCompletedProductWithSummary
                {
                    CompletedItemId = combined.combined.item.Id,
                    ManufacturingProcessId = combined.combined.item.ManufacturingProcessId,
                    CompletedItemName = product.Name,
                    SerialNumber = combined.productDevelopment.SerialNumber
                }).ToListAsync(cancellationToken);
    }
}