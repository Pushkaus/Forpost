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

    public async Task<CompositionTechCard?> GetCompositionTechCardsAsync(Guid techCardId,
        CancellationToken cancellationToken)
    {
        var queryResults = await _dbContext.TechCards
        .Where(tc => tc.Id == techCardId)
        .Join(_dbContext.TechCardItems,
            techCard => techCard.Id,
            techCardItem => techCardItem.TechCardId,
            (techCard, techCardItem) => new { techCard, techCardItem })
        .Join(_dbContext.Products,
            combined => combined.techCardItem.ProductId,
            product => product.Id,
            (combined, product) => new { combined.techCard, combined.techCardItem, product })
        .Join(_dbContext.TechCardSteps,
            techCardWithItems => techCardWithItems.techCard.Id,
            techCardStep => techCardStep.TechCardId,
            (techCardWithItems, techCardStep) => new { techCardWithItems, techCardStep })
        .Join(_dbContext.Steps,
            techCardWithItemsAndStep => techCardWithItemsAndStep.techCardStep.StepId,
            step => step.Id,
            (techCardWithItemsAndStep, step) => new { techCardWithItemsAndStep, step })
        .Join(_dbContext.Operations,
            techCardWithItemsStep => techCardWithItemsStep.step.OperationId,
            operation => operation.Id,
            (techCardWithItemsStep, operation) => new
            {
                TechCard = techCardWithItemsStep.techCardWithItemsAndStep.techCardWithItems.techCard,
                TechCardItem = techCardWithItemsStep.techCardWithItemsAndStep.techCardWithItems.techCardItem,
                Product = techCardWithItemsStep.techCardWithItemsAndStep.techCardWithItems.product,
                TechCardStep = techCardWithItemsStep.techCardWithItemsAndStep.techCardStep,
                Step = techCardWithItemsStep.step,
                Operation = operation
            })
        .ToListAsync(cancellationToken);

    var techCard = queryResults
        .GroupBy(qr => new { qr.TechCard.Id, qr.TechCard.Number, qr.TechCard.Description })
        .Select(group => new CompositionTechCard
        {
            Id = group.Key.Id,
            Number = group.Key.Number,
            Description = group.Key.Description,
            Steps = group
                .Select(item => new StepSummary
                {
                    TechCardId = item.TechCard.Id,
                    OperationName = item.Operation.Name,
                    Description = item.Step.Description,
                    Duration = item.Step.Duration,
                    Cost = item.Step.Cost,
                    UnitOfMeasure = (UnitOfMeasure)item.Step.UnitOfMeasure
                })
                .GroupBy(s => new { s.OperationName, s.Description, s.Duration, s.Cost, s.UnitOfMeasure })
                .Select(s => s.First()) 
                .ToList(),
            Items = group
                .Select(item => new ItemSummary
                {
                    TechCardId = item.TechCard.Id,
                    ProductId = item.Product.Id,
                    ProductName = item.Product.Name,
                    Quantity = item.TechCardItem.Quantity
                })
                .GroupBy(i => new { i.ProductId, i.ProductName, i.Quantity })
                .Select(i => i.First())
                .ToList()
        })
        .FirstOrDefault();

    return techCard;
    }
}
