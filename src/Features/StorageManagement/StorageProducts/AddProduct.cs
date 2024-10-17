using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.StorageManagment;
using Forpost.Domain.StorageManagment.StorageProducts;
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
            UnitOfMeasure = UnitOfMeasure.Piece,
            Quantity = command.Quantity,
        };
        _storageProductDomainRepository.Add(product);
        return ValueTask.FromResult(Unit.Value);
    }
}
public record AddProducOnStorageCommand(Guid StorageId, Guid ProductId, int Quantity): ICommand;