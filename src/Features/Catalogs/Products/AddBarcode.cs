using Forpost.Common;
using Forpost.Domain.Catalogs.Products;
using Mediator;

namespace Forpost.Features.Catalogs.Products;

internal sealed class AddBarcodeCommandHandler : ICommandHandler<UpdateBarcodeProductCommand>
{
    private readonly IProductDomainRepository _productDomainRepository;

    public AddBarcodeCommandHandler(IProductDomainRepository productDomainRepository)
    {
        _productDomainRepository = productDomainRepository;
    }

    public async ValueTask<Unit> Handle(UpdateBarcodeProductCommand productCommand, CancellationToken cancellationToken)
    {
        var product = await _productDomainRepository.GetByIdAsync(productCommand.ProductId, cancellationToken);
        product.EnsureFoundBy(x => x.Id, productCommand.ProductId);
        product.Barcode = productCommand.Barcode;
        _productDomainRepository.Update(product);
        return Unit.Value;
    }
}

public record UpdateBarcodeProductCommand(Guid ProductId, string Barcode) : ICommand;