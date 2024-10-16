namespace Forpost.Web.Contracts.Catalogs.Products;

public sealed class BarcodeRequest
{
    public Guid ProductId { get; set; }
    public string Barcode { get; set; }
    public int Quantity { get; set; } = 1;
}