using Forpost.Application.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

internal sealed class GetByIdManufacturingOrderCompositionQueryHandler :
    IQueryHandler<GetByIdManufacturingOrderCompositionQuery, IReadOnlyCollection<ManufacturingOrderCompositionModel>>
{
    private readonly IManufacturingOrderCompositionReadRepository _manufacturingOrderCompositionReadRepository;

    public GetByIdManufacturingOrderCompositionQueryHandler(
        IManufacturingOrderCompositionReadRepository manufacturingOrderCompositionReadRepository)
    {
        _manufacturingOrderCompositionReadRepository = manufacturingOrderCompositionReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<ManufacturingOrderCompositionModel>> Handle(
        GetByIdManufacturingOrderCompositionQuery query, CancellationToken cancellationToken)
    {
        return await _manufacturingOrderCompositionReadRepository.GetCompositionByOrderIdAsync(
            query.ManufacturingOrderId, cancellationToken);
    }
}

public record GetByIdManufacturingOrderCompositionQuery(Guid ManufacturingOrderId)
    : IQuery<IReadOnlyCollection<ManufacturingOrderCompositionModel>>;