using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Domain.ProductCreating.ProductDevelopment;
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
        return await _dbContext.ManufacturingProcesses.Where(entity => entity.Id == manufacturingProcessId)
            .Join(_dbContext.TechCards,
                manufacturingProcess => manufacturingProcess.TechnologicalCardId,
                techCard => techCard.Id,
                (manufacturingProcess, techCard) => new InizializationProductDevelopment
                {
                    ManufacturingProcessId = manufacturingProcessId,
                    ProductId = techCard.ProductId,
                    BatchNumber = manufacturingProcess.BatchNumber,
                    TargetQuantity = manufacturingProcess.TargetQuantity,
                })
            .FirstOrDefaultAsync(cancellationToken);
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

    public async Task<IReadOnlyCollection<ProductDevelopmentDetails>> 
        GetAllByIssueId(Guid issueId, CancellationToken cancellationToken)
    {
        return await _dbContext.ProductDevelopments
            .Where(entity => entity.IssueId == issueId 
                             && entity.Status == ProductStatus.InProgress)
            .Join(_dbContext.Products,
                productDevelopment => productDevelopment.ProductId,
                product => product.Id,
                (productDevelopment, product) => new {productDevelopment, product})
            .Join(_dbContext.ManufacturingProcesses,
                combined => combined.productDevelopment.ManufacturingProcessId,
                manufacturingProcess => manufacturingProcess.Id,
                (combined, manufacturingProcess) => new ProductDevelopmentDetails
                {
                    ProductId = combined.product.Id,
                    ProductName = combined.product.Name,
                    ManufacturingProcessId = combined.productDevelopment.ManufacturingProcessId,
                    IssueId = combined.productDevelopment.IssueId,
                    BatchNumber = manufacturingProcess.BatchNumber,
                    SerialNumber = combined.productDevelopment.SerialNumber,
                    SettingOption = (SettingOptionRead?)combined.productDevelopment.SettingOption,
                    StatusRead = (ProductStatusRead)combined.productDevelopment.Status,
                })
            .ToListAsync(cancellationToken);
    }
}