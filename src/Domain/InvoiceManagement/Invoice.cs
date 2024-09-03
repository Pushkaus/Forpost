using Forpost.Domain.Primitives.EntityTemplates;
using Forpost.Domain.ProductCreating.Issue;

namespace Forpost.Domain.InvoiceManagement;

public sealed class Invoice : AggregateRoot
{
    public void InitialAdd()
    {
        Status = InvoiceStatus.Pending;
    }

    private Invoice(
        string number,
        Guid contractorId,
        string? description,
        int paymentPercentage,
        int daysShipment)
    {
        Number = number;
        ContractorId = contractorId;
        Description = description;
        PaymentPercentage = paymentPercentage;
        DaysShipment = daysShipment;
    }
    public static Invoice Expose(
        string number,
        Guid contractorId,
        string? description,
        int paymentPercentage,
        int daysShipment)
    {
        var invoice = new Invoice(number, contractorId, description, paymentPercentage, daysShipment);
        
        invoice.InitialAdd();
        
        invoice.Raise(new InvoiceExposed(invoice.Id));
        
        return invoice;
    }
    public string Number { get; set; } = null!;
    public Guid ContractorId { get; set; }
    public string? Description { get; set; }
    /// <summary>
    /// Процент оплаты
    /// </summary>
    public int PaymentPercentage { get; set; }
    /// <summary>
    /// Количество дней до отгрузки
    /// </summary>
    public int DaysShipment { get; set; }
    public InvoiceStatus Status { get; set; } = default!;
    public DateTimeOffset? DateShipment { get; set; }
}