using Forpost.Common.Exceptions;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.StorageManagment;
using Forpost.Store.Postgres;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Features.StorageManagement;

internal sealed class ScanBarcodesCommandHandler : ICommandHandler<ScanBarcodesCommand>
{
    private readonly IProductDomainRepository _productDomainRepository;
    private readonly IStorageProductDomainRepository _storageProductDomainRepository;

    public ScanBarcodesCommandHandler(IProductDomainRepository productDomainRepository,
        IStorageProductDomainRepository storageProductDomainRepository)
    {
        _productDomainRepository = productDomainRepository;
        _storageProductDomainRepository = storageProductDomainRepository;
    }

    public async ValueTask<Unit> Handle(ScanBarcodesCommand command, CancellationToken cancellationToken)
    {
        var product = await _productDomainRepository.GetByBarcodeAsync(command.Barcode, cancellationToken);
        if (product == null)
            throw new EntityNotFoundException("Продукт с таким штрих-кодом не найден.");
        
        var storageProduct =
            await _storageProductDomainRepository.GetByProductIdAsync(product.Id, cancellationToken);
        
        var updatedStorageProduct = storageProduct ?? new StorageProduct
        {
            ProductId = product.Id,
            StorageId = command.StorageId,
            UnitOfMeasure = UnitOfMeasure.Piece,
            Quantity = 1
        };

        if (storageProduct != null)
        {
            updatedStorageProduct.Quantity += 1;
            _storageProductDomainRepository.Update(updatedStorageProduct);
        }
        else
            _storageProductDomainRepository.Add(updatedStorageProduct);

        return Unit.Value;
    }
}

public record ScanBarcodesCommand(Guid StorageId, string Barcode) : ICommand;