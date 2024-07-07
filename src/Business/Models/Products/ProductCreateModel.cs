namespace Forpost.Store.Repositories.Models.Products;

public class ProductCreateModel
{
    public string Name { get; set; }
    public string? Version { get; set; }
    public decimal Cost { get; set; }
}