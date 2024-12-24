using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Forpost.Application.Contracts.Catalogs.TechCards;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardItems;
using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Forpost.Domain.ProductCreating.ProductDevelopment;
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

    public Task<IReadOnlyCollection<TechCardItemModel>> GetTechCardItemsByProductDevelopmentId(Guid productDevelopmentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)> GetAllByIssueId(Guid issueId, CancellationToken cancellationToken, int skip, int limit)
    {
        throw new NotImplementedException();
    }

    public Task<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)> GetAllAsync(string? filterExpression, object?[]? filterValues, int skip, int limit,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}