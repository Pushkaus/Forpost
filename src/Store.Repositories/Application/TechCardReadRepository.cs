using Forpost.Application.Contracts.Catalogs.TechCards;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class TechCardReadRepository: ITechCardReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public TechCardReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

   public async Task<CompositionTechCard?> GetCompositionTechCardsAsync(Guid techCardId, CancellationToken cancellationToken)
{
    var queryResults = await _dbContext.TechCards
        .Where(tc => tc.Id == techCardId)
        .Select(techCard => new 
        {
            TechCard = techCard,
            TechCardItems = _dbContext.TechCardItems.Where(item => item.TechCardId == techCard.Id).ToList(),
            Steps = (from techCardStep in _dbContext.TechCardSteps
                     join step in _dbContext.Steps on techCardStep.StepId equals step.Id into gj
                     from subStep in gj.DefaultIfEmpty()
                     where techCardStep.TechCardId == techCard.Id
                     select new { techCardStep, SubStep = subStep }).ToList()
        })
        .ToListAsync(cancellationToken);

    var techCard = queryResults
        .Select(result => new CompositionTechCard
        {
            Id = result.TechCard.Id,
            Number = result.TechCard.Number,
            Description = result.TechCard.Description,
            Steps = result.Steps
                .Where(s => s.SubStep != null) // Поддержка шагов
                .Select(item => new StepSummary
                {
                    TechCardId = item.techCardStep.TechCardId,
                    OperationName = item.SubStep != null ? _dbContext.Operations.FirstOrDefault(o => o.Id == item.SubStep.OperationId)?.Name : string.Empty,
                    Description = item.SubStep?.Description ?? string.Empty,
                    Duration = item.SubStep?.Duration ?? TimeSpan.Zero,
                    Cost = item.SubStep?.Cost ?? 0m,
                    UnitOfMeasure = (UnitOfMeasure)(item.SubStep?.UnitOfMeasure ?? default)
                })
                .ToList(),
            Items = result.TechCardItems
                .Select(item => new ItemSummary
                {
                    TechCardId = item.TechCardId,
                    ProductId = item.ProductId,
                    ProductName = _dbContext.Products.FirstOrDefault(p => p.Id == item.ProductId)?.Name ?? string.Empty,
                    Quantity = item.Quantity
                })
                .ToList()
        })
        .FirstOrDefault();

    return techCard;
}

}
