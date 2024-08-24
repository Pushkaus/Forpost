using Forpost.Store.Enums;

namespace Forpost.Business.Sortout;

public class StorageProduct
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public UnitOfMeassure UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; } = default!;
}