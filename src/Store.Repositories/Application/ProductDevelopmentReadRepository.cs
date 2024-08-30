using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ProductDevelopmentReadRepository: IProductDevelopmentReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ProductDevelopmentReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductDevelopmentSummary?> 
        GetSummaryByManufacturingProcessIdAsync(Guid manufacturingProcessId, CancellationToken cancellationToken)
    {
        return await _dbContext.ManufacturingProcesses
            .Where(entity => entity.Id == manufacturingProcessId)
            .Join(_dbContext.TechCards,
                manProcess => manProcess.TechnologicalCardId,
                techCard => techCard.Id,
                (manProcess, techCard) => new {manProcess, techCard})
            .Join(_dbContext.Products,
                combined => combined.techCard.ProductId,
                product => product.Id,
                (combined, product) => new ProductDevelopmentSummary
                {
                    ManufacturingProcessId = combined.manProcess.Id,
                    ProductId = combined.techCard.ProductId,
                    BatchNumber = combined.manProcess.BatchNumber,
                    TargetQuantity = combined.manProcess.TargetQuantity
                }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<LocationDeterminationProduct?> GetLocationProduct(Guid productDevelopmentId, CancellationToken cancellationToken)
    {
        var location = await _dbContext.ProductDevelopments.Where(entity => entity.Id == productDevelopmentId)
            .Join(_dbContext.Issues,
                product => product.ManufacturingProcessId,
                issue => issue.ManufacturingProcessId,
                (product, issue) => new { product, issue })
            .Join(_dbContext.TechCardSteps,
                combined => combined.issue.StepId,
                techCardStep => techCardStep.StepId,
                (combined, techCardStep) => new { combined, techCardStep })
            .Join(_dbContext.ManufacturingProcesses,
                combined => combined.combined.product.ManufacturingProcessId,
                manufacturingProcess => manufacturingProcess.Id,
                (combined, manufacturingProcess) => new { combined, manufacturingProcess })
            .Where(entity =>
                entity.combined.techCardStep.TechCardId == entity.manufacturingProcess.TechnologicalCardId)
            .Where(entity => entity.combined.techCardStep.Number == entity.combined.combined.product.IssueNumber)
            .FirstOrDefaultAsync(cancellationToken);
            return new LocationDeterminationProduct
            {
                ProductDevelopmentId = location.combined.combined.product.ProductId,
                Issue = location.combined.combined.issue.Id
            };
    }
}