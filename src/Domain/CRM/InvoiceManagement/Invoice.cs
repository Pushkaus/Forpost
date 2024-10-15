using Forpost.Domain.CRM.InvoiceManagement.Events;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.CRM.InvoiceManagement;

public sealed class Invoice : AggregateRoot
{
    public void InitialAdd()
    {
        Status = InvoiceStatus.Pending;
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
        Status = InvoiceStatus.Completed;
    }
    public string Number { get; set; } = null!;
    public Guid ContractorId { get; set; }
    public string? Description { get; set; }
    /// <summary>
    /// Процент оплаты
    /// </summary>
    public decimal PaymentPercentage { get; set; }
    /// <summary>
    /// Количество дней до отгрузки
    /// </summary>
    public int DaysShipment { get; set; }
    public InvoiceStatus Status { get; set; } = default!;
    public DateTimeOffset? DateShipment { get; set; }
}