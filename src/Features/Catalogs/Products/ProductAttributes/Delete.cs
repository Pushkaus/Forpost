using Forpost.Domain.Catalogs.Products.ProductAttributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.ProductAttributes;

internal sealed class DeleteProductAttributeByIdCommandHandler: ICommandHandler<DeleteProductAttributeByIdCommand>
{
    private readonly IProductAttributeDomainRepository _productAttributeDomainRepository;

    public DeleteProductAttributeByIdCommandHandler(IProductAttributeDomainRepository productAttributeDomainRepository)
    {
        _productAttributeDomainRepository = productAttributeDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteProductAttributeByIdCommand command, CancellationToken cancellationToken)
    {
        _productAttributeDomainRepository.DeleteById(command.Id);
        return ValueTask.FromResult(Unit.Value);
    }
}
public record DeleteProductAttributeByIdCommand(Guid Id): ICommand;