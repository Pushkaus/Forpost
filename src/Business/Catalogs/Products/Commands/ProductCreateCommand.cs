namespace Forpost.Business.Catalogs.Products.Commands;

public class ProductCreateCommand
{
    public string Name { get; set; } = default!;
    public string? Version { get; set; }
    public decimal Cost { get; set; }
}