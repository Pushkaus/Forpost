namespace Forpost.Application.Contracts.ProductCreating.CompositionProduct;

public sealed class CompositionProductGroupModel
{
    public Guid ProductDevelopmentId { get; set; }
    public string ParentProductName { get; set; }
    public string SerialNumber { get; set; }
    public IReadOnlyCollection<CompletedProductCompositionModel> CompletedProducts { get; set; } 
        = Array.Empty<CompletedProductCompositionModel>();
}

public sealed class CompletedProductCompositionModel
{
    public Guid CompletedProductId { get; set; }
    public string ItemName { get; set; }
    public string SerialNumber { get; set; }

}