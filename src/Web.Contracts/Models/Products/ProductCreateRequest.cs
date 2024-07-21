namespace Forpost.Web.Contracts.Models.Products;

public class ProductCreateRequest
{
    public string Name { get; set; }
    public string? Version { get; set; }
    public decimal Cost { get; set; }
}