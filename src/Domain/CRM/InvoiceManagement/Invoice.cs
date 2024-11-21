using Forpost.Domain.CRM.InvoiceManagement.Events;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.CRM.InvoiceManagement;

public sealed class Invoice : AggregateRoot
{
    public string Number { get; private set; }
    public Guid ContractorId { get; private set; }
    public string? Description { get; private set; }
    public DateTimeOffset? PaymentDeadline { get; private set; }
    public DateTimeOffset? DateShipment { get; private set; }
    public DateTimeOffset? DateClosing { get; private set; }
    public Priority Priority { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public InvoiceStatus InvoiceStatus { get; private set; }


    /// <summary>
    /// Завести счет
    /// </summary>
    public static Invoice Create(string numberPrefix,
        Guid contractorId,
        string? description,
        Priority priority,
        PaymentStatus paymentStatus,
        DateTimeOffset? paymentDeadline)
    {
        var number = GenerateNumber(numberPrefix);
        var invoice = new Invoice(number, contractorId, description, null, null, priority, paymentStatus,
            paymentDeadline,
            InvoiceStatus.Created);
        invoice.Raise(new InvoiceCreated(invoice.Id));
        return invoice;
    }

    public void ChangePriority(int priority)
    {
        Priority = Priority.FromValue(priority);
    }

    public void ChangePaymentStatus(int paymentStatus)
    {
        PaymentStatus = PaymentStatus.FromValue(paymentStatus);
    }

    public void SetShipmentDate(DateTimeOffset dateShipment)
    {
        DateShipment = dateShipment;
    }

    private Invoice(string number,
        Guid contractorId,
        string? description,
        DateTimeOffset? dateShipment,
        DateTimeOffset? dateClosing,
        Priority priority,
        PaymentStatus paymentStatus,
        DateTimeOffset? paymentDeadline,
        InvoiceStatus invoiceStatus)
    {
        Number = number;
        ContractorId = contractorId;
        Description = description;
        DateShipment = dateShipment;
        DateClosing = dateClosing;
        Priority = priority;
        PaymentDeadline = paymentDeadline;
        PaymentStatus = paymentStatus;
        InvoiceStatus = invoiceStatus;
    }

    private static string GenerateNumber(string numberPrefix)
    {
        return $"{numberPrefix}-{DateTime.Now.Year}";
    }
}

