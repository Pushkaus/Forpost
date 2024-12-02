using Forpost.Application.Contracts.ProductCreating.ManufacturingOrders;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingOrders;

internal sealed class
    GetByIdManufacturingOrderQueryHandler : IQueryHandler<GetByIdManufacturingOrderQuery, ManufacturingOrderModel?>
{
    private readonly IManufacturingOrderReadRepository _manufacturingOrderReadRepository;

    public GetByIdManufacturingOrderQueryHandler(IManufacturingOrderReadRepository manufacturingOrderReadRepository)
    {
        _manufacturingOrderReadRepository = manufacturingOrderReadRepository;
    }

    public async ValueTask<ManufacturingOrderModel?> Handle(GetByIdManufacturingOrderQuery query,
        CancellationToken cancellationToken) =>
        await _manufacturingOrderReadRepository.GetManufacturingOrderByIdAsync(query.Id, cancellationToken);
}

public record GetByIdManufacturingOrderQuery(Guid Id) : IQuery<ManufacturingOrderModel?>;