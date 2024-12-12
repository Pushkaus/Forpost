namespace Forpost.Web.Contracts.Catalogs.Products.ProductCompatibilities;

public sealed class ProductCompatibilityRequest
{
    public Guid ProductId { get; set; }
    public Guid ParentProductId { get; set; }
}