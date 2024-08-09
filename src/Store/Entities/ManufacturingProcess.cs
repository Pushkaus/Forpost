using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public sealed class ManufacturingProcess: IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid TechnologicalCardId { get; set; }
    /// <summary>
    /// Номер партии
    /// </summary>
    public string BatchNumber { get; set; }
    /// <summary>
    /// Дополнительная информация о продукте в ходе производственного процесса
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
    public TechnologicalCard TechnologicalCard { get; set; } = null!;
}