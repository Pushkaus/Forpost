namespace Forpost.Store.Entities;

public class StorageProduct
{
    public StorageProduct(Guid productId, Guid storageId, string unitOfMeasure, decimal quantity)
    {
        ProductId = productId;
        StorageId = storageId;
        UnitOfMeasure = unitOfMeasure;
        Quantity = quantity;
    }
    public class StorageProductDto
    {
        public string ProductName { get; set; }
        public string StorageName { get; set; }
        public decimal Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
    }
    public Guid StorageId { get; set; }
    public Guid ProductId { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
    public Storage Storage { get; set; }
    public Product Product { get; set; }
}