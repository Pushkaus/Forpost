namespace Forpost.Store.Repositories.Models.TechCardStep;

public sealed class StepsInTechCard
{
    public Guid TechCardId { get; set; }
    public Guid StepId { get; set; }
    public string StepName { get; set; } = null!;
    public string? StepDescription { get; set; }
    /// <summary>
    ///     Номер в очереди
    /// </summary>
    public int Number { get; set; }

    public Guid Id { get; set; }
}