using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts.StorageManagment;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class EntryStorageHIstoryReadRepository : IEntryStorageHistoryReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public EntryStorageHIstoryReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(IReadOnlyCollection<EntryStorageHistoryModel> Entries, int TotalCount)> GetAllEntries(
        EntryStorageHistoryFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.EntryStorageHistories.Join(_dbContext.Products,
                entry => entry.ProductId,
                product => product.Id,
                (entry, product) => new { entry, product })
            .Join(_dbContext.Storages,
                combined => combined.entry.StorageId,
                storage => storage.Id,
                (combined, storage) => new EntryStorageHistoryModel
                {
                    Id = combined.entry.Id,
                    StorageId = combined.entry.StorageId,
                    StorageName = storage.Name,
                    ProductId = combined.entry.ProductId,
                    ProductName = combined.product.Name,
                    Purchased = combined.product.Purchased,
                    Quantity = combined.entry.Quantity,
                    EntryDate = combined.entry.EntryDate
                });
        if (filter.Purchased.HasValue)
        {
            query = query.Where(e => e.Purchased == filter.Purchased.Value);
        }

        if (filter.Year.HasValue)
        {
            query = query.Where(e => e.EntryDate.Year == filter.Year.Value);
        }

        if (filter.Month.HasValue)
        {
            query = query.Where(e => e.EntryDate.Month == filter.Month.Value);
        }

        if (filter.Days.HasValue)
        {
            query = query.Where(e => e.EntryDate.Day == filter.Days.Value);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var result = await query.Skip(filter.Skip).Take(filter.Limit).ToListAsync(cancellationToken);

        return (result, totalCount);
    }
}