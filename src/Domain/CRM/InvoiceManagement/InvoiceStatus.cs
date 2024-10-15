using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.CRM.InvoiceManagement;

public sealed class InvoiceStatus: SmartEnumeration<InvoiceStatus>
{
    public static readonly InvoiceStatus Pending = new(nameof(Pending), 100);
    public static readonly InvoiceStatus InProgress = new(nameof(InProgress), 200);
    public static readonly InvoiceStatus Completed = new(nameof(Completed), 300);
    public static readonly InvoiceStatus Cancelled = new(nameof(Cancelled), 400);
    
    private InvoiceStatus(string name, int value) : base(name, value) { }
}