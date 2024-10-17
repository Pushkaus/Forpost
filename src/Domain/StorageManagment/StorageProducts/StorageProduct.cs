using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Primitives.EntityTemplates;
using Forpost.Domain.StorageManagment.Events;

namespace Forpost.Domain.StorageManagment.StorageProducts;

public sealed class StorageProduct : AggregateRoot
{
    public void ScanningProductOnStorage(Guid productId, Guid storageId, int quantity)
    {
        Raise(new ProductOnStorageScanned(productId, storageId, quantity));
    }
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
}