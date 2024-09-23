using Forpost.Application.Contracts.InvoiceManagment.CompositionInvoices;
using Forpost.Application.Contracts.ProductCreating.CompletedProducts;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class CompletedProductReadRepository: ICompletedProductReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public CompletedProductReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<CompletedProductModel>> 
        GetAllByProductId(Guid productId, CancellationToken cancellationToken)
    {
        return await _dbContext.CompletedProducts.Where(c => c.ProductId == productId 
                                                             && c.Status == CompletedProductStatus.OnStorage)
            .Join(_dbContext.ProductDevelopments,
                completed => completed.ProductDevelopmentId,
                productDevelopment => productDevelopment.Id,
                (completed, productDevelopment) => new { completed, productDevelopment })
            .Join(_dbContext.Products,
                combined => combined.productDevelopment.ProductId,
                product => product.Id,
                (combined, product) => new CompletedProductModel
                {
                    Id = combined.completed.Id,
                    Name = product.Name,
                    ProductId = combined.completed.ProductDevelopmentId,
                    SerialNumber = combined.productDevelopment.SerialNumber
                })
            .ToListAsync(cancellationToken);
    }

    public async Task<(IReadOnlyCollection<CompletedProductModel> CompletedProducts, int TotalCount)> 
        GetAllOnStorage(CancellationToken cancellationToken, int skip, int limit)
    {
        var result = await _dbContext.CompletedProducts.Where(c => c.Status == CompletedProductStatus.OnStorage)
            .Join(_dbContext.ProductDevelopments,
                completed => completed.ProductDevelopmentId,
                productDevelopment => productDevelopment.Id,
                (completed, productDevelopment) => new { completed, productDevelopment })
            .Join(_dbContext.Products,
                combined => combined.productDevelopment.ProductId,
                product => product.Id,
                (combined, product) => new CompletedProductModel
                {
                    Id = combined.completed.Id,
                    Name = product.Name,
                    ProductId = combined.completed.ProductDevelopmentId,
                    SerialNumber = combined.productDevelopment.SerialNumber
                })
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);
        var totalCount = result.Count();
        return (result, totalCount);
    }
}