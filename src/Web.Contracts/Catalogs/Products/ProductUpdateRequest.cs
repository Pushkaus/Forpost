namespace Forpost.Web.Contracts.Catalogs.Products;

public class ProductUpdateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Purchased { get; set; }
    public Guid CategoryId { get; set; }
}