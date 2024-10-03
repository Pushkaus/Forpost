namespace Forpost.Web.Contracts.ProductCreating;

public sealed class CompleteIssueRequest
{
    public IReadOnlyCollection<Guid> ProductDevelopmentIds { get; set; }
}