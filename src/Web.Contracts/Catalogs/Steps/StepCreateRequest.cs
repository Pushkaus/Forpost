using Forpost.Domain.Catalogs.Steps;

namespace Forpost.Web.Contracts.Catalogs.Steps;

public sealed class StepCreateRequest
{
    /// <summary>
    ///     Ссылка на тех.карту
    /// </summary>
    public Guid TechCardId { get; set; }

    /// <summary>
    ///     Ссылка на операцию (пайка/мойка/сборка и тд)
    /// </summary>
    public Guid OperationId { get; set; }

    /// <summary>
    ///     Описание задачи
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Длительность задачи
    /// </summary>
    public TimeSpan Duration { get; set; }

    /// <summary>
    ///     Стоимость задачи
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary>
    ///     Единица измерения
    /// </summary>
    public UnitOfMeasure UnitOfMeasure { get; set; }
}