namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardSteps;

public sealed class TechCardStepModel
{
    public Guid Id { get; set; }
    public string TechCardNumber { get; set; }
    public Guid TechCardId { get; set; }
    public string OperationName { get; set; }
    public Guid StepId { get; private set; }
    /// <summary>
    /// Номер в очереди
    /// </summary>
    public int Number { get; private set; }
}