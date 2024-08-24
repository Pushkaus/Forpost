namespace Forpost.Business.Catalogs.Products.Commands;

public class ProductUpdateCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Version { get; set; }
    public decimal Cost { get; set; }
}