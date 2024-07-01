namespace Forpost.Store.Repositories.Models.Products;

public class CreateProductRequest
{
    public string Name { get; set; }
    public string? Version { get; set; }
    public decimal Cost { get; set; }
}