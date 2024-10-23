using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Barcodes;

public sealed class ProductBarcode: DomainEntity
{
    public Guid ProductId { get; set; }
    public string Barcode { get; set; } = null!;
    public string Nomenclature { get; set; } = null!;
}