using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Forpost.Application.Contracts.ProductCreating.CompletedProducts;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class CompletedProductReadRepository : ICompletedProductReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public CompletedProductReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<CompletedProductModel>>
        GetAllByProductId(Guid productId, CancellationToken cancellationToken)
    {
        return await _dbContext.CompletedProducts.Where(c => c.ProductId == productId
                                                             && c.Status == CompletedProductStatus.OnStorage)
            .Join(_dbContext.ProductDevelopments,
                completed => completed.ProductDevelopmentId,
                productDevelopment => productDevelopment.Id,
                (completed, productDevelopment) => new { completed, productDevelopment })
            .Join(_dbContext.Products,
                combined => combined.productDevelopment.ProductId,
                product => product.Id,
                (combined, product) => new CompletedProductModel
                {
                    Id = combined.completed.Id,
                    Name = product.Name,
                    ProductDevelopmentId = combined.completed.ProductDevelopmentId,
                    SerialNumber = combined.productDevelopment.SerialNumber
                })
            .ToListAsync(cancellationToken);
    }

    public async Task<(IReadOnlyCollection<CompletedProductModel> CompletedProducts, int TotalCount)> GetAllOnStorage(
        string? filterExpression,
        object?[]? filterValues,
        int skip,
        int limit,
        CancellationToken cancellationToken)
    {
        // Начинаем запрос, фильтруя по статусу
        var query = _dbContext.CompletedProducts
            .Where(c => c.Status == CompletedProductStatus.OnStorage)
            .Join(
                _dbContext.ProductDevelopments,
                completed => completed.ProductDevelopmentId,
                productDevelopment => productDevelopment.Id,
                (completed, productDevelopment) => new { completed, productDevelopment }
            )
            .Join(
                _dbContext.Products,
                combined => combined.productDevelopment.ProductId,
                product => product.Id,
                (combined, product) => new CompletedProductModel
                {
                    Id = combined.completed.Id,
                    Name = product.Name,
                    ProductDevelopmentId = combined.completed.ProductDevelopmentId,
                    SerialNumber = combined.productDevelopment.SerialNumber
                }
            );
        if (!string.IsNullOrWhiteSpace(filterExpression))
        {
            try
            {
                query = query.Where($"{filterExpression}.Contains(@0)", filterValues);
            }
            catch (ParseException ex)
            {
                throw new ArgumentException("Некорректное выражение фильтрации.", ex);
            }
        }

        // Получаем общее количество записей после фильтрации
        var totalCount = await query.CountAsync(cancellationToken);

        // Получаем конечный список с применением пагинации
        var completedProducts = await query
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);

        return (completedProducts, totalCount);
    }

    public async Task<(IReadOnlyCollection<CompletedProductModel> CompletedProducts, int TotalCount)> GetAll(
        string? filterExpression, object?[]? filterValues, int skip, int limit,
        CancellationToken cancellationToken)
    {
        var query = _dbContext.CompletedProducts
            .Join(
                _dbContext.ProductDevelopments,
                completed => completed.ProductDevelopmentId,
                productDevelopment => productDevelopment.Id,
                (completed, productDevelopment) => new { completed, productDevelopment }
            )
            .Join(
                _dbContext.Products,
                combined => combined.productDevelopment.ProductId,
                product => product.Id,
                (combined, product) => new CompletedProductModel
                {
                    Id = combined.completed.Id,
                    Name = product.Name,
                    ProductDevelopmentId = combined.completed.ProductDevelopmentId,
                    SerialNumber = combined.productDevelopment.SerialNumber
                }
            );
        if (!string.IsNullOrWhiteSpace(filterExpression))
        {
            try
            {
                query = query.Where($"{filterExpression}.Contains(@0)", filterValues);
            }
            catch (ParseException ex)
            {
                throw new ArgumentException("Некорректное выражение фильтрации.", ex);
            }
        }
        var totalCount = await query.CountAsync(cancellationToken);
        var completedProducts = await query
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);

        return (completedProducts, totalCount);
    }
}