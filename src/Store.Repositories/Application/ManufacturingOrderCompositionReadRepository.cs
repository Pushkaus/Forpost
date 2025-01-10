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
            .Where(x => x.ManufacturingProcessOrderId == manufacturingOrderId)
            .Join(_dbContext.TechCards,
                composition => composition.TechCardId,
                techCard => techCard.Id,
                (composition, techCard) => new { composition, techCard })
            .Join(_dbContext.Products,
                combined => combined.techCard.ProductId,
                product => product.Id,
                (combined, product) => new ManufacturingOrderCompositionModel
                {
                    Id = combined.composition.Id,
                    ManufacturingProcessOrderId = combined.composition.ManufacturingProcessOrderId,
                    TechCardId = combined.composition.TechCardId,
                    TechCardNumber = combined.techCard.Number,
                    ProductId = combined.techCard.ProductId,
                    ProductName = product.Name,
                    Quantity = combined.composition.Quantity
                })
            .ToListAsync(cancellationToken);
}