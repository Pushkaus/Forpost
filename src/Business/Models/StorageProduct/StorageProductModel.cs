namespace Forpost.Business.Models.StorageProduct;

public class StorageProductModel
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; }
}