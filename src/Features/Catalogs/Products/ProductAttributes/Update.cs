using Forpost.Common;
using Forpost.Domain.Catalogs.Products.ProductAttributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.ProductAttributes;

internal sealed class UpdateProductAttributeCommandHandler : ICommandHandler<UpdateProductAttributeCommand>
{
    private readonly IProductAttributeDomainRepository _productAttributeDomainRepository;

    public UpdateProductAttributeCommandHandler(IProductAttributeDomainRepository productAttributeDomainRepository)
    {
        _productAttributeDomainRepository = productAttributeDomainRepository;
    }

    public async ValueTask<Unit> Handle(UpdateProductAttributeCommand command, CancellationToken cancellationToken)
    {
        var productUpdate = await _productAttributeDomainRepository.GetByIdAsync(command.Id, cancellationToken);

        if (productUpdate == null) throw ForpostErrors.NotFound<ProductAttribute>(command.Id);

        productUpdate.UpdatePossibleValues(command.Values);
        _productAttributeDomainRepository.Update(productUpdate);

        return Unit.Value;
    }
}

public record UpdateProductAttributeCommand(Guid Id, List<string> Values) : ICommand;