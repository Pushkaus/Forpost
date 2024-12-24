using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardOperations;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class TechCardOperationReadRepository : ITechCardOperationReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public TechCardOperationReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EntityPagedResult<TechCardOperationModel>> GetTechCardOperationsAsync(Guid techCardId, TechCardOperationFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.TechCardOperations
            .Where(tcs => tcs.TechCardId == techCardId)
            .Join(_dbContext.Operations,
                combined => combined.OperationId,
                operation => operation.Id,
                (combined, operation) => new TechCardOperationModel
                {
                    Id = combined.Id,
                    TechCardNumber = _dbContext.TechCards
                        .Where(tc => tc.Id == combined.TechCardId)
                        .Select(tc => tc.Number)
                        .FirstOrDefault() ?? string.Empty,
                    TechCardId = combined.TechCardId,
                    OperationName = operation.Name,
                    OperationId = combined.OperationId,
                    Number = combined.Number
                })
            .AsQueryable();

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .OrderBy(x=>x.Number)
            .ToListAsync(cancellationToken);

        return new EntityPagedResult<TechCardOperationModel>
        {
            TotalCount = totalCount,
            Items = items
        };
    }


    public Task<TechCardOperationModel> GetTechCardStepAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}