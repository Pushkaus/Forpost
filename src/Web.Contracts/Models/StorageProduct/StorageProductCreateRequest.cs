using Forpost.Domain.Catalogs.Steps;

namespace Forpost.Web.Contracts.Models.StorageProduct;

public class StorageProductCreateRequest
{
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}