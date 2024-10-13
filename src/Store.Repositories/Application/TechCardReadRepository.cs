using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
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
                    select new { techCardStep, SubStep = subStep }).ToList(),
                Product = _dbContext.Products.FirstOrDefault(p => p.Id == techCard.ProductId),
            })
            .ToListAsync(cancellationToken);

        var techCard = queryResults
            .Select(result => new CompositionTechCardModel
            {
                Id = result.TechCard.Id,
                Number = result.TechCard.Number,
                ProductName = result.Product.Name,
                Description = result.TechCard.Description,
                Steps = result.Steps
                    .Where(s => s.SubStep != null) 
                    .Select(item => new StepSummary
                    {
                        Id = item.SubStep.Id,
                        TechCardId = item.techCardStep.TechCardId,
                        OperationName = item.SubStep != null
                            ? _dbContext.Operations.FirstOrDefault(o => o.Id == item.SubStep.OperationId)?.Name
                            : string.Empty,
                        Description = item.SubStep?.Description ?? string.Empty,
                        Duration = item.SubStep?.Duration ?? TimeSpan.Zero,
                        Cost = item.SubStep?.Cost ?? 0m,
                        UnitOfMeasure = (UnitOfMeasure)(item.SubStep?.UnitOfMeasure ?? default)
                    })
                    .ToList(),
                Items = result.TechCardItems
                    .Select(item => new ItemSummary
                    {
                        Id = item.Id,
                        TechCardId = item.TechCardId,
                        ProductId = item.ProductId,
                        ProductName = _dbContext.Products.FirstOrDefault(p => p.Id == item.ProductId)?.Name ??
                                      string.Empty,
                        Quantity = item.Quantity
                    })
                    .ToList()
            })
            .FirstOrDefault();

        return techCard;
    }

    public async Task<(IReadOnlyCollection<TechCardModel> TechCards, int TotalCount)> GetAllAsync(
        string? filterExpression,
        object?[]? filterValues,
        int skip,
        int limit,
        CancellationToken cancellationToken)
    {
        // Получаем общее количество техкарточек
        var totalCount = await _dbContext.TechCards.CountAsync(cancellationToken);

        // Начинаем формировать запрос
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
                });

        // Применение фильтрации, если выражение задано
        if (!string.IsNullOrWhiteSpace(filterExpression))
        {
            try
            {
                // Применяем фильтрацию на запросе
                query = query.Where($"{filterExpression}.Contains(@0)", filterValues);
            }
            catch (ParseException ex)
            {
                throw new ArgumentException("Некорректное выражение фильтрации.", ex);
            }
        }

        // Обновляем общее количество техкарточек после применения фильтрации
        totalCount = await query.CountAsync(cancellationToken);

        // Получаем отфильтрованный и разбитый на страницы список техкарточек
        var techCards = await query
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);

        return (techCards, totalCount);
    }
}