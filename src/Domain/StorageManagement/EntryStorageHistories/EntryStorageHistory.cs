using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.StorageManagement.EntryStorageHistories;

public sealed class EntryStorageHistory: DomainEntity
{
    public Guid StorageId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTimeOffset EntryDate { get; set; }
}