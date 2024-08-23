namespace Forpost.Web.Contracts.Models.Operations;

public sealed class OperationRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}