using System.Diagnostics;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Events.Products;

internal sealed class ProductInInvoiceAddedHandler : IDomainEventHandler<ProductInInvoiceAdded>
{
    private readonly ILogger<ProductInInvoiceAddedHandler> _logger;
    private readonly IStorageProductService _storageProductService;

    public ProductInInvoiceAddedHandler(
        ILogger<ProductInInvoiceAddedHandler> logger, IStorageProductService storageProductService)
    {
        _logger = logger;
        _storageProductService = storageProductService;
    }

    public async Task HandleAsync(ProductInInvoiceAdded domainEvent, CancellationToken cancellationToken = default)
    {
        await _storageProductService.WriteOffAsync(domainEvent.ProductId, domainEvent.Quantity, cancellationToken);
        Debug.WriteLine($"Произошлоа списание со склада в количестве {domainEvent.Quantity}");
    }
}