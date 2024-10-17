namespace Forpost.Application.Contracts.StorageManagment;

public sealed class EntryStorageHistoryModel
{
    public Guid Id { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; } = string.Empty;
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public bool? Purchased { get; set; }
    public int Quantity { get; set; }
    public DateTimeOffset EntryDate { get; set; }
}