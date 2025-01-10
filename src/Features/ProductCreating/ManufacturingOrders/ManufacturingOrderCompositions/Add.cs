using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Domain.ProductCreating.ManufacturingOrders.Contracts;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

internal sealed class
    AddManufacturingOrderCompositionCommandHandler : ICommandHandler<AddManufacturingOrderCompositionCommand, Guid>
{
    private readonly IManufacturingOrderCompositionDomainRepository _manufacturingOrderCompositionDomainRepository;

    public AddManufacturingOrderCompositionCommandHandler(
        IManufacturingOrderCompositionDomainRepository manufacturingOrderCompositionDomainRepository)
    {
        _manufacturingOrderCompositionDomainRepository = manufacturingOrderCompositionDomainRepository;
    }

    public ValueTask<Guid> Handle(AddManufacturingOrderCompositionCommand command, CancellationToken cancellationToken)
    {
        var manufacturingOrderComposition =
            ManufacturingOrderComposition.Create(command.ManufacturingOrderId, command.TechCardId, command.Quantity);
        return ValueTask.FromResult(_manufacturingOrderCompositionDomainRepository.Add(manufacturingOrderComposition));
    }
}

public record AddManufacturingOrderCompositionCommand(Guid ManufacturingOrderId, Guid TechCardId, int Quantity)
    : ICommand<Guid>;