using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public sealed class ManufacturingProcessDetails: IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid ManufacturingProcessId { get; set; }
    /// <summary>
    /// Номер партии
    /// </summary>
    public string BatchNumber { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public ProductDetails ProductDetails { get; set; }
    public int CurrentQuantity { get; set; }
    public int TargetQuantity { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public ManufacturingProcess ManufacturingProcess { get; set; } = null!;

}