using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class TechCardReadRepository : ITechCardReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public TechCardReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CompositionTechCardModel?> GetCompositionTechCardsAsync(Guid techCardId,
        CancellationToken cancellationToken)
    {
        var techCard = await _dbContext.TechCards
            .Where(tc => tc.Id == techCardId)
            .Select(tc => new
            {
                TechCard = tc,
                ProductName = _dbContext.Products
                    .Where(p => p.Id == tc.ProductId)
                    .Select(p => p.Name)
                    .FirstOrDefault()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (techCard == null)
        {
            return null;
        }

        var techCardItems = await _dbContext.TechCardItems
            .Where(item => item.TechCardId == techCardId)
            .Select(item => new ItemSummary
            {
                Id = item.Id,
                TechCardId = item.TechCardId,
                ProductId = item.ProductId,
                ProductName = _dbContext.Products
                    .Where(p => p.Id == item.ProductId)
                    .Select(p => p.Name)
                    .FirstOrDefault() ?? string.Empty,
                Quantity = item.Quantity
            })
            .ToListAsync(cancellationToken);

        var steps = await _dbContext.TechCardSteps
            .Where(techCardStep => techCardStep.TechCardId == techCardId)
            .Join(_dbContext.Steps,
                techCardStep => techCardStep.StepId,
                step => step.Id,
                (techCardStep, step) => new { techCardStep, step })
            .Join(_dbContext.Operations,
                combined => combined.step.OperationId,
                operation => operation.Id,
                (combined, operation) => new StepSummary
                {
                    Id = combined.step.Id,
                    OperationName = operation.Name,
                    OperationId = combined.step.OperationId,
                    Description = combined.step.Description,
                    Duration = combined.step.Duration
                })
            .ToListAsync(cancellationToken);


        return new CompositionTechCardModel
        {
            Id = techCard.TechCard.Id,
            Number = techCard.TechCard.Number,
            ProductName = techCard.ProductName ?? string.Empty,
            Description = techCard.TechCard.Description,
            Steps = steps,
            Items = techCardItems
        };
    }


    public async Task<EntityPagedResult<TechCardModel>> GetAllAsync(TechCardFilter filter,
        CancellationToken cancellationToken)
    {
        var query = _dbContext.TechCards
            .Join(_dbContext.Products,
                techCard => techCard.ProductId,
                product => product.Id,
                (techCard, product) => new TechCardModel
                {
                    Id = techCard.Id,
                    Number = techCard.Number,
                    Description = techCard.Description,
                    ProductId = techCard.ProductId,
                    ProductName = product.Name
                })
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Number))
        {
            query = query.Where(tc => tc.Number.Contains(filter.Number));
        }

        if (filter.ProductId.HasValue)
        {
            query = query.Where(tc => tc.ProductId == filter.ProductId.Value);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);

        return new EntityPagedResult<TechCardModel>
        {
            TotalCount = totalCount,
            Items = items
        };
    }
}