namespace Forpost.Application.Contracts.StorageManagement;

public sealed class StorageProductModel
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public string StorageName { get; set; }
    public Guid StorageId { get; set; }
}