namespace Forpost.Application.Contracts.Catalogs.Products;

public sealed class ProductModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Purchased  { get;set;}
    public Guid? CategoryId { get; set; }
    public string CategoryName { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}