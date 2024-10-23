namespace Forpost.Web.Contracts.StorageManagement.StorageProduct;

public sealed class ScanBarcodeRequest
{
    public Guid StorageId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string Barcode { get; set; }
}