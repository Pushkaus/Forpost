using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public sealed class Issue: IEntity
{
    public Guid Id { get; set; }

    /// <summary>
    /// Номер задачи в очереди
    /// </summary>
    public string Number { get; set; } = null!;
    public string Name { get; set; } = null!;
    /// <summary>
    /// Описание задачи
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Длительность задачи
    /// </summary>
    public TimeSpan Duration { get; set; }
    /// <summary>
    /// Стоимость задачи, 
    /// </summary>
    public decimal Cost { get; set; }
    /// <summary>
    /// Целевое количество
    /// </summary>
    public int TargetQuantity { get; set; }
    /// <summary>
    /// Единица измерения
    /// </summary>
    public UnitOfMeassure UnitOfMeassure { get; set; }
    public Guid OperationId { get; set; }
}