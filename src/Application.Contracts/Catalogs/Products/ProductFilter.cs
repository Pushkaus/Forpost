namespace Forpost.Application.Contracts.Catalogs.Products;

public sealed class ProductFilter
{
    public string? Name { get; set; }
    public Guid? CategoryId { get; set; }
    public string? CategoryName { get; set; } = string.Empty;
    public bool? Purchased { get; set; }
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
}