namespace Forpost.Web.Contracts.Catalogs.Products;

public class ProductCreateRequest
{
    public string Name { get; set; }
    public bool Purchased { get; set; } = false;
    public Guid CategoryId { get; set; } = Guid.Empty;
}