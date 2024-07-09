namespace Forpost.Web.Contracts.Models.StorageProduct;

public class StorageProductCreateRequest
{
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}