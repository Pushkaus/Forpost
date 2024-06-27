namespace Forpost.Store.Repositories.Models.Products;

public class ProductCreateModel
{
    public string Name { get; set; }
    public string? Version { get; set; }
    public decimal Cost { get; set; }
    public Guid CreatedById { get; set; }
    public Guid UpdatedById { get; set; }
}