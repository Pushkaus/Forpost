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
                    Status = (ProductStatus)manufacturingProcess.Status,
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

    public async Task<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)> 
        GetAllByIssueId(Guid issueId, CancellationToken cancellationToken, int skip, int limit)
    {
        var result = await _dbContext.ProductDevelopments
            .Where(entity => entity.IssueId == issueId 
                             && entity.Status == ProductStatus.InProgress)
            .Join(_dbContext.ManufacturingProcesses,
                productDevelopment => productDevelopment.ManufacturingProcessId,
                manufacturingProcess => manufacturingProcess.Id,
                (productDevelopment, manufacturingProcess) => new { productDevelopment, manufacturingProcess })
            .Join(_dbContext.Products,
                combined => combined.productDevelopment.ProductId,
                product => product.Id,
                (combined, product) => new {combined, product})
            .Join(_dbContext.Issues,
                combined => combined.combined.productDevelopment.IssueId,
                issue => issue.Id,
                (combined, issue) => new {combined, issue})
            .Join(_dbContext.Steps,
                combined => combined.issue.StepId,
                step => step.Id,
                (combined, step) => new {combined, step})
            .Join(_dbContext.Operations,
                combined => combined.step.OperationId,
                operation => operation.Id,
                (combined, operation) => new ProductDevelopmentModel
                {
                    Id = combined.combined.combined.combined.productDevelopment.Id,
                    ProductId = combined.combined.combined.combined.productDevelopment.ProductId,
                    ProductName = combined.combined.combined.product.Name,
                    ManufacturingProcessId = combined.combined.combined.combined.productDevelopment.ManufacturingProcessId,
                    IssueId = combined.combined.combined.combined.productDevelopment.IssueId,
                    OperationName = operation.Name,
                    BatchNumber = combined.combined.combined.combined.manufacturingProcess.BatchNumber,
                    SerialNumber = combined.combined.combined.combined.productDevelopment.SerialNumber,
                    SettingOption = (SettingOptionRead?)combined.combined.combined.combined.productDevelopment.SettingOption,
                    StatusRead = (ProductStatusRead)combined.combined.combined.combined.productDevelopment.Status,
                })
            .Skip(skip)
            .Take(limit)
            .Where(entity => entity.StatusRead != ProductStatusRead.Completed 
                             && entity.StatusRead != ProductStatusRead.Cancelled)
            .ToListAsync(cancellationToken);
        var totalCount = result.Count;
        return (result, totalCount);
    }
    
    public async Task<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)> 
        GetAllAsync(CancellationToken cancellationToken, int skip, int limit)
    {
        var totalCount = await _dbContext.ProductDevelopments.CountAsync(cancellationToken);
        var result = await _dbContext.ProductDevelopments
            .Join(_dbContext.ManufacturingProcesses,
                productDevelopment => productDevelopment.ManufacturingProcessId,
                manufacturingProcess => manufacturingProcess.Id,
                (productDevelopment, manufacturingProcess) => new { productDevelopment, manufacturingProcess })
            .Join(_dbContext.Products,
                combined => combined.productDevelopment.ProductId,
                product => product.Id,
                (combined, product) => new {combined, product})
            .Join(_dbContext.Issues,
                combined => combined.combined.productDevelopment.IssueId,
                issue => issue.Id,
                (combined, issue) => new {combined, issue})
            .Join(_dbContext.Steps,
                combined => combined.issue.StepId,
                step => step.Id,
                (combined, step) => new {combined, step})
            .Join(_dbContext.Operations,
                combined => combined.step.OperationId,
                operation => operation.Id,
                (combined, operation) => new ProductDevelopmentModel
                {
                    Id = combined.combined.combined.combined.productDevelopment.Id,
                    ProductId = combined.combined.combined.combined.productDevelopment.ProductId,
                    ProductName = combined.combined.combined.product.Name,
                    ManufacturingProcessId = combined.combined.combined.combined.productDevelopment.ManufacturingProcessId,
                    IssueId = combined.combined.combined.combined.productDevelopment.IssueId,
                    OperationName = operation.Name,
                    BatchNumber = combined.combined.combined.combined.manufacturingProcess.BatchNumber,
                    SerialNumber = combined.combined.combined.combined.productDevelopment.SerialNumber,
                    SettingOption = (SettingOptionRead?)combined.combined.combined.combined.productDevelopment.SettingOption,
                    StatusRead = (ProductStatusRead)combined.combined.combined.combined.productDevelopment.Status,
                })
            .Skip(skip)
            .Take(limit)
            .Where(entity => entity.StatusRead != ProductStatusRead.Completed 
                             && entity.StatusRead != ProductStatusRead.Cancelled)
            .ToListAsync(cancellationToken);
        return (result, totalCount);
    }
}