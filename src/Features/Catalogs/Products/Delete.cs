using Forpost.Domain.Catalogs.Products;
using Mediator;

namespace Forpost.Features.Catalogs.Products;

internal sealed class DeleteProductByIdCommandHandler: ICommandHandler<DeleteProductByIdCommand>
{
    private readonly IProductDomainRepository _productDomainRepository;

    public DeleteProductByIdCommandHandler(IProductDomainRepository productDomainRepository)
    {
        _productDomainRepository = productDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
    {
        _productDomainRepository.DeleteById(command.Id);
        return Unit.ValueTask;
    }
}
public record DeleteProductByIdCommand(Guid Id): ICommand;