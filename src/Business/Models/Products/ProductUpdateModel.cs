namespace Forpost.Business.Models.Products;

public class ProductUpdateModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Version { get; set; }
    public decimal Cost { get; set; }
}