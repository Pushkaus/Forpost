using Forpost.Domain.Catalogs.Barcodes;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.StorageManagment;
using Forpost.Domain.StorageManagment.StorageProducts;
using Forpost.Features.Catalogs.Barcodes.ProductBarcodes;
using Mediator;


namespace Forpost.Features.StorageManagement;

internal sealed class ScanBarcodeProductOnStorageHandler : ICommandHandler<ScanBarcodeProductOnStorageCommand, bool>
{
    private readonly IStorageProductDomainRepository _storageProductDomainRepository;
    private readonly IProductBarcodeDomainRepository _productBarcodeDomainRepository;

    public ScanBarcodeProductOnStorageHandler(IStorageProductDomainRepository storageProductDomainRepository,
        IProductBarcodeDomainRepository productBarcodeDomainRepository)
    {
        _storageProductDomainRepository = storageProductDomainRepository;
        _productBarcodeDomainRepository = productBarcodeDomainRepository;
    }

    public async ValueTask<bool> Handle(ScanBarcodeProductOnStorageCommand command, CancellationToken cancellationToken)
    {
        var productBarcode = await _productBarcodeDomainRepository.GetByBarcode(command.Barcode, cancellationToken);
        if (productBarcode == null)
        {
            var newProductBarcode = new ProductBarcode
            {
                ProductId = command.ProductId,
                Barcode = command.Barcode,
                Nomenclature = BarcodeProcessor.GetNomenclatureFromBarcode(command.Barcode) ??
                               throw new Exception(
                                   $"Штрихкод {command.Barcode} не имеет валидную номенклатуру.")
            };
            _productBarcodeDomainRepository.Add(newProductBarcode);
        }
        var storageProduct =
            await _storageProductDomainRepository.GetByProductIdAndStorageIdAsync(command.ProductId,
                command.StorageId, cancellationToken);
        if (storageProduct == null)
        {
            storageProduct = new StorageProduct
            {
                ProductId = command.ProductId,
                StorageId = command.StorageId,
                UnitOfMeasure = UnitOfMeasure.Piece,
                Quantity = command.Quantity,
            };
            _storageProductDomainRepository.Add(storageProduct);
        }
        else
        {
            storageProduct.Quantity += command.Quantity;
            _storageProductDomainRepository.Update(storageProduct);
        }

        storageProduct.ScanningProductOnStorage(command.ProductId, command.StorageId, command.Quantity);
        return true;
    }
}

public record ScanBarcodeProductOnStorageCommand(Guid StorageId, Guid ProductId, string Barcode, int Quantity)
    : ICommand<bool>;