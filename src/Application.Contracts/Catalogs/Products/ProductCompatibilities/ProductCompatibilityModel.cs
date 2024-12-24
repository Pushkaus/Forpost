namespace Forpost.Application.Contracts.Catalogs.Products.ProductCompatibilities;

public sealed class ProductCompatibilityModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public Guid ParentProductId { get; set; }
    public string ParentProductName { get; set; }
}
