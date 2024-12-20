namespace Forpost.Web.Contracts.Catalogs.TechCardSteps;

public sealed class UpdateTechCardStepRequest
{
    public Guid TechCardId { get; set; }
    public Guid StepId { get; set; }
    public int Number { get; set; }
}