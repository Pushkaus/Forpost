using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Store.Repositories.Application;

internal sealed class ProductDevelopmentReadRepository: IProductDevelopmentReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ProductDevelopmentReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<InizializationProductDevelopment?> 
        GetSummaryByManufacturingProcessIdAsync(Guid manufacturingProcessId, CancellationToken cancellationToken)
    {
        return await _dbContext.ProductDevelopments
            .Where(entity => entity.ManufacturingProcessId == manufacturingProcessId)
            .Join(_dbContext.Products,
                productDevelopment => productDevelopment.ProductId,
                product => product.Id,
                (productDevelopment, product) => new {productDevelopment, product})
            .Join(_dbContext.ManufacturingProcesses,
                combined => combined.productDevelopment.ManufacturingProcessId,
                process => process.Id,
                (combined, process) => new InizializationProductDevelopment
                {
                    ManufacturingProcessId = combined.productDevelopment.ManufacturingProcessId,
                    ProductId = combined.productDevelopment.ProductId,
                    BatchNumber = process.BatchNumber,
                    TargetQuantity = process.TargetQuantity
                }).FirstOrDefaultAsync(cancellationToken);
    }
}