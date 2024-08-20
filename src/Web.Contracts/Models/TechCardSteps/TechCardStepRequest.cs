namespace Forpost.Web.Contracts.Models.TechCardSteps;

internal sealed class TechCardStepRequest
{
    public Guid TechCardId { get; set; }
    public Guid StepId { get; set; }

    /// <summary>
    ///     Номер в очереди
    /// </summary>
    public int Number { get; set; }

    public Guid Id { get; set; }
}