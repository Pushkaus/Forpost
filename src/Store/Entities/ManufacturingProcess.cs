using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public sealed class ManufacturingProcess: IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid TechnologicalCardId { get; set; }
    /// <summary>
    /// Дополнительная информация о продукте в ходе производственного процесса
    /// </summary>
    public Guid ProductDetailsId { get; set; }
    /// <summary>
    /// Номер партии
    /// </summary>
    public string BatchNumber { get; set; }
    /// <summary>
    /// Текущее количество продукта из производственного процесса
    /// </summary>
    public int CurrentQuantity { get; set; }
    /// <summary>
    /// Целевое количество продукта в производственном процессе
    /// </summary>
    public int TargetQuantity { get; set; }
    public Status Status { get; set; }
    /// <summary>
    /// Дата начала выполнения производственного процесса
    /// </summary>
    public DateTimeOffset StartTime { get; set; }
    /// <summary>
    /// Дата завершения выполнения производственного процесса
    /// </summary>
    public DateTimeOffset EndTime { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
}