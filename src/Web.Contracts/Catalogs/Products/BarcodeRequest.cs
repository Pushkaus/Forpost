using ZXing;

namespace Forpost.Web.Contracts.Catalogs.Products;

public sealed class BarcodeRequest
{
    public Guid ProductId { get; set; }
    public string Barcode { get; set; }
}