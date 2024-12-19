using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.TechCards.Steps;

namespace Forpost.Store.Repositories.Models.StorageProduct;

public sealed class ProductsOnStorageModel
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; }
}