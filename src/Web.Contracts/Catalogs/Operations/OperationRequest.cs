namespace Forpost.Web.Contracts.Catalogs.Operations;

public sealed class OperationRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}