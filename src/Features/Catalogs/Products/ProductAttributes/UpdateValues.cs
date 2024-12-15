using Forpost.Common;
using Forpost.Domain.Catalogs.Products.ProductAttributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.ProductAttributes;

internal sealed class UpdateProductAttributeValuesCommandHandler: ICommandHandler<UpdateProductAttributeValuesCommand>
{
    private readonly IProductAttributeDomainRepository _productAttributeDomainRepository;

    public UpdateProductAttributeValuesCommandHandler(IProductAttributeDomainRepository productAttributeDomainRepository)
    {
        _productAttributeDomainRepository = productAttributeDomainRepository;
    }

    public async ValueTask<Unit> Handle(UpdateProductAttributeValuesCommand command, CancellationToken cancellationToken)
    {
        var productAttribute = await _productAttributeDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        if (productAttribute == null) throw ForpostErrors.NotFound<ProductAttribute>(command.Id);
        
        productAttribute.UpdatePossibleValues(command.Values);
        
        _productAttributeDomainRepository.Update(productAttribute);
        
        return Unit.Value;
    }
}

public record UpdateProductAttributeValuesCommand(Guid Id, List<string> Values) : ICommand; 