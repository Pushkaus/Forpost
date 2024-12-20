using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.TechCards.Steps;

namespace Forpost.Web.Contracts.Catalogs.Steps;

public sealed class StepCreateRequest
{
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
}