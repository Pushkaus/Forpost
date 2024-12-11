namespace Forpost.Web.Contracts.StorageManagement.StorageProduct;

public class StorageProductCreateRequest
{
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public int Quantity { get; set; }
}