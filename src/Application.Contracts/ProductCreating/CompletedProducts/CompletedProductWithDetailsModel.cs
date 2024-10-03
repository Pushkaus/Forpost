using Forpost.Application.Contracts.ProductCreating.CompositionProduct;
using Forpost.Application.Contracts.ProductCreating.Issues;

namespace Forpost.Application.Contracts.ProductCreating.CompletedProducts;

internal sealed class CompletedProductWithDetailsModel
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public Guid ProductId { get; set; }
    public Guid ProductDevelopmentId { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string BatchNumber { get; set; } = string.Empty;
    public Guid ManufacturingProcessId { get; set; }
    public string TechCardNumber { get; set; } = string.Empty;
    public Guid TechCardId { get; set; }
    public IReadOnlyCollection<IssueModel> Issues { get; set; } = Array.Empty<IssueModel>();
    public IReadOnlyCollection<CompletedProductCompositionModel> CompletedItems { get; set; } 
        = Array.Empty<CompletedProductCompositionModel>();
}