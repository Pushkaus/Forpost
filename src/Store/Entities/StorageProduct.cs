using Forpost.Store.Contracts;

namespace Forpost.Store.Entities;

public class StorageProduct: IEntity
{
    public StorageProduct(Guid productId, Guid storageId, string unitOfMeasure, decimal quantity)
    {
        ProductId = productId;
        StorageId = storageId;
        UnitOfMeasure = unitOfMeasure;
        Quantity = quantity;
    }
    
    public Guid StorageId { get; set; }
    public Guid ProductId { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
    public Storage Storage { get; set; }
    public Product Product { get; set; }
    public Guid Id { get; set; }
}