using Forpost.Common.EntityAnnotations;
using Forpost.Domain.Catalogs.Steps;

namespace Forpost.Domain.Sortout;

public class StorageProduct : IEntity
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
    public Guid StorageId { get; set; }
    public string StorageName { get; set; } = default!;
    public Guid Id { get; set; }
}