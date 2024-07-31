using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public sealed class Component: IEntity
{
    public Guid ParentId { get; set; }
    public Guid DaughterId { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }

    public Product ParentProduct { get; set; }
    public Product DaughterProduct { get; set; }
    public Guid Id { get; set; }
}