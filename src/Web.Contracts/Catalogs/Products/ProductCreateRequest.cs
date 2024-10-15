namespace Forpost.Web.Contracts.Catalogs.Products;

public class ProductCreateRequest
{
    public string Name { get; set; }
    public string? Barcode { get; set; }
}