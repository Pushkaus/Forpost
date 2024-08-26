namespace Forpost.Web.Contracts.Models.Products;

public class ProductUpdateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Version { get; set; }
}