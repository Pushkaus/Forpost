using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Domain.Catalogs.TechCardItems;
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
    
    public async Task<IReadOnlyCollection<TechCardItem>>
        GetTechCardItemsById(Guid productDevelopmentId, CancellationToken cancellationToken)
    {
        return await _dbContext.ProductDevelopments.Where(p => p.Id == productDevelopmentId)
            .Join(_dbContext.ManufacturingProcesses,
                productDevelopment => productDevelopment.ManufacturingProcessId,
                manufacturingProcess => manufacturingProcess.Id,
                (productDevelopment, manufacturingProcess) => new { productDevelopment, manufacturingProcess })
            .Join(_dbContext.TechCardItems,
                combined => combined.manufacturingProcess.TechnologicalCardId,
                techCardItems => techCardItems.TechCardId,
                (combined, techCardItems) => new TechCardItem
                {
                    Id = techCardItems.Id,
                    TechCardId = techCardItems.TechCardId,
                    ProductId = techCardItems.ProductId,
                    Quantity = techCardItems.Quantity
                })
            .ToListAsync(cancellationToken);
    }
}