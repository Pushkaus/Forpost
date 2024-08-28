using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.Catalogs.TechCardSteps;

/// <summary>
/// Сущность, связывающая этапы и тех.карту
/// </summary>
public sealed class TechCardStep : DomainEntity
{
    public Guid TechCardId { get; set; }
    public Guid StepId { get; set; }

    /// <summary>
    /// Номер в очереди
    /// </summary>
    public int Number { get; set; }
}