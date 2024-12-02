using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

public interface IManufacturingOrderCompositionReadRepository : IApplicationReadRepository
{
    public Task<IReadOnlyCollection<ManufacturingOrderCompositionModel>> GetCompositionByOrderIdAsync(
        Guid manufacturingOrderId, CancellationToken cancellationToken);
}