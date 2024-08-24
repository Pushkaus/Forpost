namespace Forpost.Business.Catalogs.TechCardSteps;

public sealed class TechCardStepCreateCommand
{
    public Guid TechCardId { get; set; }
    public Guid StepId { get; set; }

    /// <summary>
    ///     Номер в очереди
    /// </summary>
    public int Number { get; set; }
}