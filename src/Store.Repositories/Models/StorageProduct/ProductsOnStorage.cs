using Forpost.Store.Enums;

namespace Forpost.Store.Repositories.Models.StorageProduct;

public sealed class ProductsOnStorage
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public UnitOfMeassure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; }
}