using Forpost.Domain.Catalogs.Products.ProductCompatibilities;
using Mediator;

namespace Forpost.Features.Catalogs.Products.ProductCompatibilities;

internal sealed class
    DeleteProductCompatibilityByIdCommandHandler : ICommandHandler<DeleteProductCompatibilityByIdCommand>
{
    private readonly IProductCompabilityDomainRepository _productCompabilityDomainRepository;

    public DeleteProductCompatibilityByIdCommandHandler(IProductCompabilityDomainRepository productCompabilityDomainRepository)
    {
        _productCompabilityDomainRepository = productCompabilityDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteProductCompatibilityByIdCommand command, CancellationToken cancellationToken)
    {
        _productCompabilityDomainRepository.DeleteById(command.Id);
        return Unit.ValueTask;
    }
}

public record DeleteProductCompatibilityByIdCommand(Guid Id) : ICommand;