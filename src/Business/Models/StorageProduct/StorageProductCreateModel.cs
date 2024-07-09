namespace Forpost.Business.Models.StorageProduct;

public class StorageProductCreateModel
{
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}