using Forpost.Domain.Catalogs.Steps;

namespace Forpost.Web.Contracts.StorageManagement.StorageProduct;

public class StorageProductResponse
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; }
}