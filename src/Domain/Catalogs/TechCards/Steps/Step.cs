using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.TechCards.Steps;

/// <summary>
/// Этап. Операция с характеристиками.
/// </summary>
public sealed class Step : DomainEntity
{
    /// <summary>
    /// Ссылка на операцию (пайка/мойка/сборка и тд)
    /// </summary>
    public Guid OperationId { get; private set; }
    
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; private set; }

    /// <summary>
    /// Длительность
    /// </summary>
    public TimeSpan Duration { get; private set; }

    public static Step Create(Guid operationId, string? description, TimeSpan duration) 
        => new(operationId, description, duration);

    private Step(Guid operationId, string? description, TimeSpan duration)
    {
        OperationId = operationId;
        Description = description;
        Duration = duration;
    }
}