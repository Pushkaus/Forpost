using System.Diagnostics;
using Forpost.Business.EventHanding;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Events.Products;

internal sealed class ProductInInvoiceAddedNotificationHandler : IDomainEventHandler<ProductInInvoiceAdded>
{
    private readonly IStorageProductRepository _storageProductRepository;
    private readonly ILogger<ProductInInvoiceAddedNotificationHandler> _logger;

    public ProductInInvoiceAddedNotificationHandler(IStorageProductRepository storageProductRepository,
        ILogger<ProductInInvoiceAddedNotificationHandler> logger)
    {
        _storageProductRepository = storageProductRepository;
        _logger = logger;
    }
    
    public async Task HandleAsync(ProductInInvoiceAdded domainEvent, CancellationToken cancellationToken = default)
    {
        Debug.WriteLine("Пишу в телегу");
    }
}