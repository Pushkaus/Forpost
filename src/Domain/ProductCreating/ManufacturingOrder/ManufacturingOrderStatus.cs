using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.ProductCreating.ManufacturingOrder;

public sealed class ManufacturingOrderStatus: SmartEnumeration<ManufacturingOrderStatus>
{
    public static readonly ManufacturingOrderStatus Pending = new (nameof(Pending), 100);
    public static readonly ManufacturingOrderStatus Executed = new (nameof(Executed), 200);
    public static readonly ManufacturingOrderStatus Closed = new (nameof(Closed), 300);
    public ManufacturingOrderStatus(string name, int value) : base(name, value)
    {
    }
}