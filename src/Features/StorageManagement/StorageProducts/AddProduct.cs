using Forpost.Domain.StorageManagement.StorageProducts;
using Mediator;

namespace Forpost.Features.StorageManagement.StorageProducts;

internal sealed class AddProducOnStorageCommandHandler: ICommandHandler<AddProducOnStorageCommand>
{
    private readonly IStorageProductDomainRepository _storageProductDomainRepository;

    public AddProducOnStorageCommandHandler(IStorageProductDomainRepository storageProductDomainRepository)
    {
        _storageProductDomainRepository = storageProductDomainRepository;
    }

    public ValueTask<Unit> Handle(AddProducOnStorageCommand command, CancellationToken cancellationToken)
    {
        var product = new StorageProduct
        {
            ProductId = command.ProductId,
            StorageId = command.StorageId,
            Quantity = command.Quantity,
        };
        _storageProductDomainRepository.Add(product);
        return ValueTask.FromResult(Unit.Value);
    }
}
public record AddProducOnStorageCommand(Guid StorageId, Guid ProductId, int Quantity): ICommand;