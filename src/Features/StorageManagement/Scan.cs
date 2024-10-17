using Forpost.Common.Exceptions;
using Forpost.Domain.Catalogs.Barcodes;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.StorageManagment;
using Forpost.Domain.StorageManagment.StorageProducts;
using Forpost.Store.Postgres;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Features.StorageManagement;

internal sealed class ScanBarcodesCommandHandler : ICommandHandler<ScanBarcodeCommand, bool>
{
    private readonly IStorageProductDomainRepository _storageProductDomainRepository;
    private readonly IProductBarcodeDomainRepository _productBarcodeDomainRepository;

    public ScanBarcodesCommandHandler(IStorageProductDomainRepository storageProductDomainRepository,
        IProductBarcodeDomainRepository productBarcodeDomainRepository)
    {
        _storageProductDomainRepository = storageProductDomainRepository;
        _productBarcodeDomainRepository = productBarcodeDomainRepository;
    }

    public async ValueTask<bool> Handle(ScanBarcodeCommand command, CancellationToken cancellationToken)
    {
        var productBarcode = await _productBarcodeDomainRepository.GetByBarcode(command.Barcode, cancellationToken);
        if (productBarcode == null)
            return false;

        var storageProduct =
            await _storageProductDomainRepository.GetByProductIdAndStorageIdAsync(productBarcode.ProductId,
                command.StorageId, cancellationToken);
        if (storageProduct == null)
        {
            storageProduct = new StorageProduct
            {
                ProductId = productBarcode.ProductId,
                StorageId = command.StorageId,
                UnitOfMeasure = UnitOfMeasure.Piece,
                Quantity = productBarcode.Quantity,
            };
            _storageProductDomainRepository.Add(storageProduct);
        }
        else
        {
            storageProduct.Quantity += productBarcode.Quantity;
            _storageProductDomainRepository.Update(storageProduct);
        }
        storageProduct.ScanningProductOnStorage(storageProduct.ProductId, storageProduct.StorageId,
            productBarcode.Quantity);
        return true;
    }
}

public record ScanBarcodeCommand(Guid StorageId, string Barcode) : ICommand<bool>;