using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.TechCards.TechCardSteps;

/// <summary>
/// Сущность, связывающая этапы и тех.карту
/// </summary>
public sealed class TechCardStep : DomainEntity
{
    public Guid TechCardId { get; private set; }
    public Guid StepId { get; private set; }
    /// <summary>
    /// Номер в очереди
    /// </summary>
    public int Number { get; private set; }

    public static TechCardStep Add(Guid techCardId, Guid stepId, int number) 
        => new(techCardId, stepId, number);

    private TechCardStep(Guid techCardId, Guid stepId, int number)
    {
        TechCardId = techCardId;
        StepId = stepId;
        Number = number;
    }

}