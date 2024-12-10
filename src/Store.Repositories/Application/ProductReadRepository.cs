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
            .GroupJoin(_dbContext.Categories,
                product => product.CategoryId,
                category => category.Id,
                (product, categories) => new { product, categories })
            .SelectMany(
                pc => pc.categories.DefaultIfEmpty(),
                (pc, category) => new ProductModel
                {
                    Id = pc.product.Id,
                    Name = pc.product.Name,
                    Purchased = pc.product.Purchased,
                    CategoryId = pc.product.CategoryId,
                    CategoryName = category != null ? category.Name : "Без категории",
                })
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }


    public async Task<EntityPagedResult<ProductModel>> GetAllAsync(ProductFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.Products.NotDeletedAt()
            .GroupJoin(_dbContext.Categories, 
                product => product.CategoryId,
                category => category.Id,
                (product, categories) => new { product, categories })
            .SelectMany(x => x.categories.DefaultIfEmpty(),
                (x, category) => new ProductModel
                {
                    Id = x.product.Id,
                    Name = x.product.Name,
                    Purchased = x.product.Purchased,
                    CategoryId = x.product.CategoryId,
                    CategoryName =  category != null ? category.Name : "Нет категории",
                    UpdatedAt = x.product.UpdatedAt
                });
        
        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));
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
            query = query.Where(p => p.CategoryName.ToLower().Contains(filter.CategoryName.ToLower()));
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