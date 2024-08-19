using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public sealed class ManufacturingProcess : IEntity, IAuditableEntity, ITimeFrameEntity
{
    public Guid TechnologicalCardId { get; set; }

    /// <summary>
    ///     Номер партии
    /// </summary>
    public string BatchNumber { get; set; } = null!;

    /// <summary>
    ///     Текущее количество продукта из производственного процесса
    /// </summary>
    public int CurrentQuantity { get; set; }

    /// <summary>
    ///     Целевое количество продукта в производственном процессе
    /// </summary>
    public int TargetQuantity { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public Guid Id { get; set; }

    /// <summary>
    ///     Дата начала выполнения производственного процесса
    /// </summary>
    public DateTimeOffset StartTime { get; set; }

    /// <summary>
    ///     Дата завершения выполнения производственного процесса
    /// </summary>
    public DateTimeOffset EndTime { get; set; }
}