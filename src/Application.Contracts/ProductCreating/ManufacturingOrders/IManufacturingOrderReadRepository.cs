using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.ProductCreating.ManufacturingOrders;

public interface IManufacturingOrderReadRepository: IApplicationReadRepository
{
    public Task<EntityPagedResult<ManufacturingOrderModel>> GetAllManufacturingOrdersAsync(
        ManufacturingOrderFilter filter, CancellationToken cancellationToken);
    public Task<ManufacturingOrderModel?> GetManufacturingOrderByIdAsync(Guid id, CancellationToken cancellationToken);
}