using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Crm.InvoiceManagement;

public sealed class PaymentStatus: SmartEnumeration<PaymentStatus>
{
    public static readonly PaymentStatus NotPaid = new (nameof(NotPaid), 100);
    public static readonly PaymentStatus AdvancePaid = new (nameof(AdvancePaid), 200);
    public static readonly PaymentStatus PaidFull = new (nameof(PaidFull), 300);

    public PaymentStatus(string name, int value) : base(name, value)
    {
    }
}