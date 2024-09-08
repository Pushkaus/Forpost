using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.SortOut;

public sealed class StorageProduct : DomainEntity
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; } = default!;
}