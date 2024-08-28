using Forpost.Domain.Catalogs.Steps;

namespace Forpost.Application.StorageManagment;

public class StorageProductCreateCommand
{
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}