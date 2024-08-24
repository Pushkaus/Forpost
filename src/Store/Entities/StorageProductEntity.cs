using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public class StorageProductEntity : IEntity
{
    public Guid StorageId { get; set; }
    public Guid ProductId { get; set; }
    public UnitOfMeassure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
    public Guid Id { get; set; }
}