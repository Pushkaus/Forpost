using Forpost.Domain.StorageManagement.EntryStorageHistories;
using Forpost.Domain.StorageManagement.Events;
using Mediator;

namespace Forpost.Features.StorageManagement.EntryStorageHistories;

public sealed class ProductOnStorageScannedNotificationHandler: INotificationHandler<ProductOnStorageScanned>
{
    private readonly IEntryStorageHistoryDomainRepository _entryStorageHistoryDomainRepository;

    public ProductOnStorageScannedNotificationHandler(IEntryStorageHistoryDomainRepository entryStorageHistoryDomainRepository)
    {
        _entryStorageHistoryDomainRepository = entryStorageHistoryDomainRepository;
    }

    public ValueTask Handle(ProductOnStorageScanned notification, CancellationToken cancellationToken)
    {
        var scannedProduct = new EntryStorageHistory
        {
            StorageId = notification.StorageId,
            ProductId = notification.ProductId,
            Quantity = notification.Quantity,
            EntryDate = TimeProvider.System.GetUtcNow()
        };
        _entryStorageHistoryDomainRepository.Add(scannedProduct);
        return ValueTask.CompletedTask;
    }
}