namespace Forpost.Web.Contracts.Catalogs.TechCardOperations;

public sealed class TechCardOperationRequest
{
    public Guid TechCardId { get; set; }
    public Guid OperationId { get; set; }
}