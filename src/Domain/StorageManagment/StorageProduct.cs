using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.StorageManagment;

public sealed class StorageProduct : DomainEntity
{
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
}