namespace Forpost.Web.Contracts.Catalogs.TechCardSteps;

public sealed class TechCardStepRequest
{
    public Guid TechCardId { get; set; }
    public Guid StepId { get; set; }

    /// <summary>
    ///     Номер в очереди
    /// </summary>
    public int Number { get; set; }
}