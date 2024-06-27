namespace Forpost.Store.Entities;

public class StorageProduct
{
    public Guid StorageId { get; set; }
    public Guid ProductId { get; set; }
    public string UnitOfMeasure { get; set; }
    public float Quantity { get; set; }
    public Storage Storage { get; set; }
    public Product Product { get; set; }
}