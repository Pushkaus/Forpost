using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public sealed class Issue: IEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    /// <summary>
    /// Операция в задаче (пайка/сборка/мойка и тд)
    /// </summary>
    public Guid OperationId { get; set; }
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
    /// Единица измерения
    /// </summary>
    public UnitOfMeassure UnitOfMeassure { get; set; }
}