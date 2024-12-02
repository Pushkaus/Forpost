using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;


namespace Forpost.Store.Repositories.Application;

internal sealed class ManufacturingOrderCompositionReadRepository : IManufacturingOrderCompositionReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ManufacturingOrderCompositionReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<ManufacturingOrderCompositionModel>> GetCompositionByOrderIdAsync(
        Guid manufacturingOrderId, CancellationToken cancellationToken) =>
        await _dbContext.ManufacturingOrderCompositions
            .Where(x=>x.ManufacturingProcessOrderId == manufacturingOrderId)
            .Join(_dbContext.Products,
                composition => composition.ProductId,
                product => product.Id,
                (composition, product) => new ManufacturingOrderCompositionModel
                {
                    Id = composition.Id,
                    ManufacturingProcessOrderId = composition.ManufacturingProcessOrderId,
                    ProductId = composition.ProductId,
                    ProductName = product.Name,
                    Quantity = composition.Quantity,
                })
            .ToListAsync(cancellationToken);
}