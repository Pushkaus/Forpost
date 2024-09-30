using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ManufacturingProcessReadRepository: IManufacturingProcessReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ManufacturingProcessReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(IReadOnlyCollection<ManufacturingProcessWithDetailsModel> ManufacturingProcesses, int TotalCount)> GetAllAsync(
    string? filterExpression,
    object?[]? filterValues,
    int skip,
    int limit,
    CancellationToken cancellationToken)
{
    // Получаем общее количество процессов без фильтрации
    var totalCount = await _dbContext.ManufacturingProcesses.CountAsync(cancellationToken);

    // Начинаем запрос с объединением таблиц
    var query = _dbContext.ManufacturingProcesses
        .Join(
            _dbContext.TechCards,
            manufacturingProcess => manufacturingProcess.TechnologicalCardId,
            techCard => techCard.Id,
            (manufacturingProcess, techCard) => new { manufacturingProcess, techCard })
        .Join(
            _dbContext.Products,
            combined => combined.techCard.ProductId,
            product => product.Id,
            (combined, product) => new ManufacturingProcessWithDetailsModel
            {
                Id = combined.manufacturingProcess.Id,
                ProductId = product.Id,
                ProductName = product.Name,
                TechCardId = combined.manufacturingProcess.TechnologicalCardId,
                TechCardNumber = combined.techCard.Number,
                BatchNumber = combined.manufacturingProcess.BatchNumber,
                CurrentQuantity = combined.manufacturingProcess.CurrentQuantity,
                TargetQuantity = combined.manufacturingProcess.TargetQuantity,
                StartTime = combined.manufacturingProcess.StartTime,
                EndTime = combined.manufacturingProcess.EndTime,
                Status = (ManufacturingProcessStatusModel)combined.manufacturingProcess.Status,
            }
        );

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

    // Обновляем общее количество процессов после фильтрации
    totalCount = await query.CountAsync(cancellationToken);

    // Получаем отфильтрованный и разбитый на страницы список процессов
    var manufacturingProcesses = await query
        .Skip(skip)
        .Take(limit)
        .ToListAsync(cancellationToken);

    return (manufacturingProcesses, totalCount);
}


    public async Task<ManufacturingProcessWithDetailsModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.ManufacturingProcesses.Where(entity => entity.Id == id)
            .Join(_dbContext.TechCards,
                manufacturingProcess => manufacturingProcess.TechnologicalCardId,
                techCard => techCard.Id,
                (manufacturingProcess, techCard) => new { manufacturingProcess, techCard })
            .Join(_dbContext.Products,
                combined => combined.techCard.ProductId,
                product => product.Id,
                (combined, product) => new ManufacturingProcessWithDetailsModel
                {
                    Id = combined.manufacturingProcess.Id,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    TechCardId = combined.manufacturingProcess.TechnologicalCardId,
                    TechCardNumber = combined.techCard.Number,
                    BatchNumber = combined.manufacturingProcess.BatchNumber,
                    CurrentQuantity = combined.manufacturingProcess.CurrentQuantity,
                    TargetQuantity = combined.manufacturingProcess.TargetQuantity,
                    StartTime = combined.manufacturingProcess.StartTime,
                    EndTime = combined.manufacturingProcess.EndTime,
                    Status = (ManufacturingProcessStatusModel)combined.manufacturingProcess.Status,
                })
            .FirstOrDefaultAsync(cancellationToken);
    }
}