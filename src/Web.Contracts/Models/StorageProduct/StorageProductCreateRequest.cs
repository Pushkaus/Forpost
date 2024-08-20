using Forpost.Store.Enums;

namespace Forpost.Web.Contracts.Models.StorageProduct;

public class StorageProductCreateRequest
{
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public UnitOfMeassure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}