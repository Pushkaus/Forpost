using Forpost.Common;
using Forpost.Domain.Catalogs.Products.ProductAttributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.ProductAttributes;

internal sealed class AddProductAttributeValuesCommandHandler: ICommandHandler<AddProductAttributeValuesCommand>
{
    private readonly IProductAttributeDomainRepository _productAttributeDomainRepository;

    public AddProductAttributeValuesCommandHandler(IProductAttributeDomainRepository productAttributeDomainRepository)
    {
        _productAttributeDomainRepository = productAttributeDomainRepository;
    }

    public async ValueTask<Unit> Handle(AddProductAttributeValuesCommand command, CancellationToken cancellationToken)
    {
        var productAttribute = await _productAttributeDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        if (productAttribute == null) throw ForpostErrors.NotFound<ProductAttribute>(command.Id);
        
        productAttribute.AddValues(command.Values);
        
        _productAttributeDomainRepository.Update(productAttribute);
        
        return Unit.Value;
    }
}

public record AddProductAttributeValuesCommand(Guid Id, List<string> Values) : ICommand; 