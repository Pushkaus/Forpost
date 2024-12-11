namespace Forpost.Features.Catalogs.Barcodes.ProductBarcodes;

public static class BarcodeProcessor
{
    /// <summary>
    /// Получение номеклатуры из штрихкода
    /// </summary>
    public static string GetNomenclatureFromBarcode(string barcode)
    {
        var parts = barcode.Split(new[] { '+', ',', ';', ' '}, StringSplitOptions.RemoveEmptyEntries);
        return parts.Length > 0 ? parts[0] : string.Empty;
    }
}