namespace Forpost.Web.Contracts.Catalogs.TechCardOperations;

public sealed class UpdateTechCardOperationRequest
{
    public Guid TechCardId { get; set; }
    public Guid OperationId { get; set; }
    public int Number { get; set; }
}