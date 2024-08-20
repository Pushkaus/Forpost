using Forpost.Store.Enums;

namespace Forpost.Business.Models.StorageProduct;

public class StorageProductModel
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public UnitOfMeassure UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; }
}