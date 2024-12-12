using Forpost.Domain.Catalogs.Products.ProductAttributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.ProductAttributes;

internal sealed class CreateProductAttributeCommandHandler : ICommandHandler<CreateProductAttributeCommand, Guid>
{
    private readonly IProductAttributeDomainRepository _productAttributeDomainRepository;

    public CreateProductAttributeCommandHandler(IProductAttributeDomainRepository productAttributeDomainRepository)
    {
        _productAttributeDomainRepository = productAttributeDomainRepository;
    }

    public ValueTask<Guid> Handle(CreateProductAttributeCommand command, CancellationToken cancellationToken)
    {
        var productAttribute = ProductAttribute.Create(command.ProductId, command.AttributeId);
        var productAttributeId = _productAttributeDomainRepository.Add(productAttribute);
        return ValueTask.FromResult(productAttributeId);
    }
}

public record CreateProductAttributeCommand(Guid ProductId, Guid AttributeId) : ICommand<Guid>;