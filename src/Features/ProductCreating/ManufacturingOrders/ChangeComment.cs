using Forpost.Common;
using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Domain.ProductCreating.ManufacturingOrders.Contracts;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingOrders;

internal sealed class
    ChangeCommentManufacturingOrderCommandHandler : ICommandHandler<ChangeCommentManufacturingOrderCommand>
{
    private readonly IManufacturingOrderDomainRepository _manufacturingOrderDomainRepository;

    public ChangeCommentManufacturingOrderCommandHandler(
        IManufacturingOrderDomainRepository manufacturingOrderDomainRepository)
    {
        _manufacturingOrderDomainRepository = manufacturingOrderDomainRepository;
    }

    public async ValueTask<Unit> Handle(ChangeCommentManufacturingOrderCommand command,
        CancellationToken cancellationToken)
    {
        var manufacturingOrder = await _manufacturingOrderDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        if (manufacturingOrder == null) throw ForpostErrors.NotFound<ManufacturingOrder>(command.Id);
        manufacturingOrder.ChangeComment(command.Comment);
        return Unit.Value;
    }
}

public record ChangeCommentManufacturingOrderCommand(Guid Id, string Comment) : ICommand;