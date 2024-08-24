using Forpost.Store.Enums;

namespace Forpost.Business.Sortout;

public class StorageProductCreateCommand
{
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public UnitOfMeassure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}