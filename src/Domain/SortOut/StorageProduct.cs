using Forpost.Common.EntityTemplates;
using Forpost.Domain.Catalogs.Steps;

namespace Forpost.Domain.SortOut;

public class StorageProduct : DomainEntity
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; } = default!;
}