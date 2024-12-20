using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardItems;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class TechCardItemReadRepository : ITechCardItemReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public TechCardItemReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EntityPagedResult<TechCardItemModel>> GetItemsByTechCardIdAsync(
        Guid techCardId,
        TechCardItemFilter filter,
        CancellationToken cancellationToken)
    {
        var query = _dbContext.TechCardItems
            .Where(item => item.TechCardId == techCardId)
            .Join(
                _dbContext.Products,
                item => item.ProductId,
                product => product.Id,
                (item, product) => new TechCardItemModel
                {
                    Id = item.Id,
                    TechCardId = item.TechCardId,
                    ProductId = item.ProductId,
                    ProductName = product.Name,
                    Quantity = item.Quantity
                }
            );

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);

        return new EntityPagedResult<TechCardItemModel>
        {
            TotalCount = totalCount,
            Items = items
        };
    }



    public Task<TechCardItemModel> GetTechCardItemAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}