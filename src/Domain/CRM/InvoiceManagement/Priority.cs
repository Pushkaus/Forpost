using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.CRM.InvoiceManagement;

public sealed class Priority: SmartEnumeration<Priority>
{
    public static readonly Priority Low = new(nameof(Low), 100);
    public static readonly Priority Normal = new(nameof(Normal), 200);
    public static readonly Priority High = new(nameof(High), 300);

    public Priority(string name, int value) : base(name, value)
    {
    }
}