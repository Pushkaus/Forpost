using Forpost.Application.Contracts.CRM.PriceLists;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Forpost.Store.Repositories.Application;

internal sealed class PriceListReadRepository : IPriceListReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public PriceListReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(IReadOnlyCollection<PriceListModel> PriceList, int TotalCount)> GetAll(PriceListFilter filter,
        CancellationToken cancellationToken)
    {
        var query = _dbContext.PriceLists.NotDeletedAt()
            .Join(_dbContext.Products,
                priceList => priceList.ProductId,
                product => product.Id,
                (priceList, product) => new { priceList, product })
            .Join(_dbContext.Operations,
                combined => combined.priceList.OperationId,
                operation => operation.Id,
                (combined, operation) => new { combined, operation })
            .Join(_dbContext.Employees,
                combined => combined.combined.priceList.UpdatedById,
                employee => employee.Id,
                (combined, employee) => new PriceListModel
                {
                    Id = combined.combined.priceList.Id,
                    OperationId = combined.combined.priceList.OperationId,
                    OperationName = combined.operation.Name,
                    ProductId = combined.combined.priceList.ProductId,
                    ProductName = combined.combined.product.Name,
                    Price = combined.combined.priceList.Price,
                    UpdatedAt = combined.combined.priceList.UpdatedAt,
                    UpdatedById = combined.combined.priceList.UpdatedById,
                    UpdatedByName = employee.FirstName + " " + employee.LastName,
                });

        if (!filter.ProductName.IsNullOrEmpty())
        {
            query.Where(x => x.ProductName == filter.ProductName);
        }

        var totalCount = await query.CountAsync(cancellationToken);
        var priceList = await query.OrderByDescending(x => x.UpdatedAt)
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);

        return (priceList, totalCount);
    }
}