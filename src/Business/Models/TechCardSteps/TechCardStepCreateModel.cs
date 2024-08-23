namespace Forpost.Business.Models.TechCardSteps;

public sealed class TechCardStepCreateModel
{
    public Guid TechCardId { get; set; }
    public Guid StepId { get; set; }

    /// <summary>
    ///     Номер в очереди
    /// </summary>
    public int Number { get; set; }

    public Guid Id { get; set; }
}