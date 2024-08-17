using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities.ProductCreating;

/// <summary>
/// Этап
/// </summary>
public sealed class Step : IEntity
{
    public Guid Id { get; set; }

    /// <summary>
    /// Ссылка на тех.карту
    /// </summary>
    public Guid TechCardId { get; set; }

    /// <summary>
    /// Ссылка на операцию (пайка/мойка/сборка и тд)
    /// </summary>
    public Guid OperationId { get; set; }

    /// <summary>
    /// Описание задачи
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Длительность задачи
    /// </summary>
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// Стоимость задачи
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary>
    /// Единица измерения
    /// </summary>
    public UnitOfMeassure UnitOfMeassure { get; set; }
}