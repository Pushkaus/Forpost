namespace Forpost.Application.Contracts.ProductCreating.CompositionProduct;

public sealed class CompositionProductGroupModel
{
    public Guid ProductDevelopmentId { get; set; }
    public string ParentProductName { get; set; }
    public string SerialNumber { get; set; }
    public IReadOnlyCollection<CompletedProductModel> CompletedProducts { get; set; } 
        = Array.Empty<CompletedProductModel>();
}

public sealed class CompletedProductModel
{
    public Guid CompletedProductId { get; set; }
    public string ItemName { get; set; }
    public string SerialNumber { get; set; }

}