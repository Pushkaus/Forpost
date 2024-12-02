using Forpost.Domain.ProductCreating.ManufacturingOrders.Contracts;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

internal sealed class DeleteManufacturingOrderCompositionCommandHandler: ICommandHandler<DeleteManufacturingOrderCompositionCommand>
{
    private readonly IManufacturingOrderCompositionDomainRepository _manufacturingOrderCompositionDomainRepository;

    public DeleteManufacturingOrderCompositionCommandHandler(IManufacturingOrderCompositionDomainRepository manufacturingOrderCompositionDomainRepository)
    {
        _manufacturingOrderCompositionDomainRepository = manufacturingOrderCompositionDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteManufacturingOrderCompositionCommand command, CancellationToken cancellationToken)
    {
        _manufacturingOrderCompositionDomainRepository.DeleteById(command.Id);
        return ValueTask.FromResult(Unit.Value);
    }
}
public record DeleteManufacturingOrderCompositionCommand(Guid Id): ICommand;