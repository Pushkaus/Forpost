using Forpost.Domain.CRM.InvoiceManagement.Events;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.CRM.InvoiceManagement;

public sealed class Invoice : AggregateRoot
{
    public void InitialAdd()
    {
        InvoiceStatus = InvoiceStatus.Pending;
    }

    public Invoice(
        string number,
        Guid contractorId,
        string? description,
        decimal paymentPercentage,
        int daysShipment)
    {
        Number = number;
        ContractorId = contractorId;
        Description = description;
        PaymentPercentage = paymentPercentage;
        DaysShipment = daysShipment;
    }
    /// <summary>
    /// Завести счёт
    /// </summary>
    public static Invoice Expose(
        string number,
        Guid contractorId,
        string? description,
        decimal paymentPercentage,
        int daysShipment)
    {
        var invoice = new Invoice(number, contractorId, description, paymentPercentage, daysShipment);
        
        invoice.InitialAdd();
        
        invoice.Raise(new InvoiceExposed(invoice.Id));
        
        return invoice;
    }
    /// <summary>
    /// Выставление даты отгрузки счета
    /// </summary>
    public void Ship(DateTimeOffset dateShipment)
    {
        DateShipment = dateShipment;
        InvoiceStatus = InvoiceStatus.Completed;
    }
    public string Number { get; set; } = null!;
    public Guid ContractorId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
    public DateTimeOffset? DateClosing { get; set; }
    public Priority Priority { get; set; } 
    public PaymentStatus PaymentStatus { get; set; }
    public InvoiceStatus InvoiceStatus { get; set; } = default!;
}