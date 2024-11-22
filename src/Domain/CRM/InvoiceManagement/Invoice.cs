using Forpost.Domain.ChangeLogs;
using Forpost.Domain.ChangeLogs.Events;
using Forpost.Domain.CRM.InvoiceManagement.Events;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.CRM.InvoiceManagement;

public sealed class Invoice : AggregateRoot
{
    public string Number { get; private set; }
    public Guid ContractorId { get; private set; }
    public string? Description { get; private set; }
    public decimal PaymentPercentage { get; private set; }
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset? PaymentDeadline { get; private set; }
    public DateTimeOffset? DateShipment { get; private set; }
    public DateTimeOffset? DateClosing { get; private set; }
    public Priority Priority { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public InvoiceStatus InvoiceStatus { get; private set; }

    public static Invoice Create(string number,
        Guid contractorId,
        string? description,
        Priority priority,
        PaymentStatus paymentStatus,
        DateTimeOffset? paymentDeadline,
        DateTimeOffset createDate)
    {
        var invoice = new Invoice(GenerateNumber(number), contractorId, description, null, null, priority, paymentStatus,
            paymentDeadline,
            InvoiceStatus.Created, createDate);

        invoice.UpdatePaymentPercentage();

        invoice.Raise(new InvoiceCreated(invoice.Id));
        return invoice;
    }

    public void ChangePriority(int priority)
    {
        var oldPriorityValue = Priority.Value;
        Priority = Priority.FromValue(priority);
        Raise(new ChangeLogAdded(Id, nameof(Priority), "Приоритет", oldPriorityValue, Priority.Value));
    }

    public void ChangePaymentStatus(int paymentStatus)
    {
        var oldPaymentStatus = PaymentStatus.Value;
        PaymentStatus = PaymentStatus.FromValue(paymentStatus);
        UpdatePaymentPercentage();

        if (oldPaymentStatus == PaymentStatus.Value) return;
        
        Raise(new ChangeLogAdded(Id, nameof(PaymentStatus), "Статус оплаты", oldPaymentStatus, PaymentStatus.Value));
    }


    public void SetPaymentPercentage(decimal percentage)
    {
        var oldPercentage = PaymentPercentage;
        if (!PaymentStatus.Equals(PaymentStatus.AdvancePaid)) return;
        PaymentPercentage = percentage;

        if (oldPercentage != PaymentPercentage)
        {
            Raise(new ChangeLogAdded(Id, nameof(PaymentPercentage), "Процент оплаты",  oldPercentage, PaymentPercentage));
        }
    }

    public void SetShipmentDate(DateTimeOffset dateShipment)
    {
        var oldDateShipment = DateShipment;
        DateShipment = dateShipment;

        if (oldDateShipment != DateShipment)
        {
            Raise(new ChangeLogAdded(Id, nameof(DateShipment),"Дата отгрузки",  oldDateShipment, DateShipment));
        }
    }


    private Invoice(string number,
        Guid contractorId,
        string? description,
        DateTimeOffset? dateShipment,
        DateTimeOffset? dateClosing,
        Priority priority,
        PaymentStatus paymentStatus,
        DateTimeOffset? paymentDeadline,
        InvoiceStatus invoiceStatus,
        DateTimeOffset createDate)
    {
        Number = number;
        ContractorId = contractorId;
        Description = description;
        DateShipment = dateShipment;
        DateClosing = dateClosing;
        CreateDate = createDate;
        Priority = priority;
        PaymentDeadline = paymentDeadline;
        PaymentStatus = paymentStatus;
        InvoiceStatus = invoiceStatus;
        UpdatePaymentPercentage();
    }

    private static string GenerateNumber(string number)
    {
        return $"{number}-{DateTime.Now.Year}";
    }
    
    private void UpdatePaymentPercentage()
    {
        PaymentPercentage = PaymentStatus.Equals(PaymentStatus.PaidFull) ? 100 :
            PaymentStatus.Equals(PaymentStatus.NotPaid) ? 0 :
            PaymentPercentage; 
    }

}
