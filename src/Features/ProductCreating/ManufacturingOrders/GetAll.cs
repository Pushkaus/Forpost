using Forpost.Application.Contracts;
using Forpost.Application.Contracts.ProductCreating.ManufacturingOrders;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingOrders;

internal sealed class
    GetAllManufacturingOrderQueryHandler : IQueryHandler<GetAllManufacturingOrderQuery,
    EntityPagedResult<ManufacturingOrderModel>>
{
    private readonly IManufacturingOrderReadRepository _manufacturingOrderReadRepository;

    public GetAllManufacturingOrderQueryHandler(IManufacturingOrderReadRepository manufacturingOrderReadRepository)
    {
        _manufacturingOrderReadRepository = manufacturingOrderReadRepository;
    }

    public async ValueTask<EntityPagedResult<ManufacturingOrderModel>> Handle(GetAllManufacturingOrderQuery query,
        CancellationToken cancellationToken) =>
        await _manufacturingOrderReadRepository.GetAllManufacturingOrdersAsync(query.Filter, cancellationToken);
}

public record GetAllManufacturingOrderQuery(ManufacturingOrderFilter Filter)
    : IQuery<EntityPagedResult<ManufacturingOrderModel>>;