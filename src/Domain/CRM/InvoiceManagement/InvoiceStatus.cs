using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.CRM.InvoiceManagement;

public sealed class InvoiceStatus: SmartEnumeration<InvoiceStatus>
{
    public static readonly InvoiceStatus Created = new (nameof(Created), 100);
    public static readonly InvoiceStatus Executed = new (nameof(Executed), 200);
    public static readonly InvoiceStatus Declined = new (nameof(Declined), 300);
    public static readonly InvoiceStatus AwaitShipment = new (nameof(AwaitShipment), 400);
    public static readonly InvoiceStatus Shipped = new (nameof(Shipped), 500);
    public static readonly InvoiceStatus Completed = new (nameof(Completed), 600);
    
    private InvoiceStatus(string name, int value) : base(name, value) { }
}