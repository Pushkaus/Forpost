using Forpost.Common;
using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Domain.ProductCreating.ManufacturingOrders.Contracts;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

internal sealed class
    ChangeQuantityManufacturingOrderCompositionCommandHandler : ICommandHandler<
    ChangeQuantityManufacturingOrderCompositionCommand>
{
    private readonly IManufacturingOrderCompositionDomainRepository _manufacturingOrderCompositionDomainRepository;

    public ChangeQuantityManufacturingOrderCompositionCommandHandler(
        IManufacturingOrderCompositionDomainRepository manufacturingOrderCompositionDomainRepository)
    {
        _manufacturingOrderCompositionDomainRepository = manufacturingOrderCompositionDomainRepository;
    }

    public async ValueTask<Unit> Handle(ChangeQuantityManufacturingOrderCompositionCommand command,
        CancellationToken cancellationToken)
    {
        var manufacturingOrderComposition =
            await _manufacturingOrderCompositionDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        if (manufacturingOrderComposition == null)
            throw ForpostErrors.NotFound<ManufacturingOrderComposition>(command.Id);
        manufacturingOrderComposition.ChangeQuantity(command.Quantity);
        return Unit.Value;
    }
}

public record ChangeQuantityManufacturingOrderCompositionCommand(Guid Id, int Quantity) : ICommand;