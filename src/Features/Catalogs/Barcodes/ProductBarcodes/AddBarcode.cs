using Forpost.Domain.Catalogs.Barcodes;
using Mediator;

namespace Forpost.Features.Catalogs.Barcodes.ProductBarcodes;

internal sealed class AddBarcodeCommandHandler : ICommandHandler<AddBarcodeProductCommand>
{
    private readonly IProductBarcodeDomainRepository _productBarcodeRepository;
    public AddBarcodeCommandHandler(IProductBarcodeDomainRepository productBarcodeRepository)
    {
        _productBarcodeRepository = productBarcodeRepository;
    }

    public async ValueTask<Unit> Handle(AddBarcodeProductCommand command, CancellationToken cancellationToken)
    {
        var productBarcode = new ProductBarcode
        {
            ProductId = command.ProductId,
            Barcode = command.Barcode,
            Quantity = command.Quantity
        };

        try
        {
            _productBarcodeRepository.Add(productBarcode);
        } 
        catch (Exception ex)
        {
            throw new Exception("Ошибка при добавлении штрихкода", ex);
        }

        return Unit.Value;
    }
}

public record AddBarcodeProductCommand(Guid ProductId, string Barcode, int Quantity) : ICommand;