using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.Products;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ProductReadRepository: IProductReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ProductReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Products
            .Join(_dbContext.Categories,
                product => product.CategoryId,
                category => category.Id,
                (product, category) => new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Purchased = product.Purchased,
                    CategoryId = product.CategoryId,
                    CategoryName = category != null ? category.Name : "Без категории",
                }).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<EntityPagedResult<ProductModel>> GetAllAsync(ProductFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.Products.NotDeletedAt()
            .Join(_dbContext.Categories,
                product => product.CategoryId,
                category => category.Id,
                (product, category) => new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Purchased = product.Purchased,
                    CategoryId = product.CategoryId,
                    CategoryName = category != null ? category.Name : "Без категории",
                    UpdatedAt = product.UpdatedAt
                });
        
        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(p => p.Name.Contains(filter.Name));
        }

        if (filter.CategoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == filter.CategoryId);
        }

        if (filter.Purchased.HasValue)
        {
            query = query.Where(p => p.Purchased == filter.Purchased.Value);
        }

        if (!string.IsNullOrEmpty(filter.CategoryName))
        {
            query = query.Where(p => p.CategoryName.Contains(filter.CategoryName));
        }
        var totalItems = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .OrderByDescending(x => x.UpdatedAt)
            .ToListAsync(cancellationToken);

        return new EntityPagedResult<ProductModel>
        {
            Items = items,
            TotalCount = totalItems,
        };

    }
}