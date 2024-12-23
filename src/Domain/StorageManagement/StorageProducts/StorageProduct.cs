using Forpost.Domain.Primitives.EntityTemplates;
using Forpost.Domain.StorageManagement.Events;

namespace Forpost.Domain.StorageManagement.StorageProducts;

public sealed class StorageProduct : AggregateRoot
{
    public void ScanningProductOnStorage(Guid productId, Guid storageId, int quantity)
    {
        Raise(new ProductOnStorageScanned(productId, storageId, quantity));
    }
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public int Quantity { get; set; }
}