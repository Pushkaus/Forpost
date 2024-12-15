using Forpost.Domain.Catalogs.Products.ProductCompatibilities;
using Mediator;

namespace Forpost.Features.Catalogs.Products.ProductCompatibilities;

internal sealed class AddProductCompabilityCommandHandler : ICommandHandler<AddProductCompabilityCommand, Guid>
{
    private readonly IProductCompabilityDomainRepository _productCompabilityDomainRepository;

    public AddProductCompabilityCommandHandler(IProductCompabilityDomainRepository productCompabilityDomainRepository)
    {
        _productCompabilityDomainRepository = productCompabilityDomainRepository;
    }

    public ValueTask<Guid> Handle(AddProductCompabilityCommand command, CancellationToken cancellationToken)
    {
        var productCompability = ProductCompatibility.Create(command.ProductId, command.ParentProductId);
        var productCompabilityId = _productCompabilityDomainRepository.Add(productCompability);
        return ValueTask.FromResult(productCompabilityId);
    }
}

public record AddProductCompabilityCommand(Guid ProductId, Guid ParentProductId) : ICommand<Guid>;