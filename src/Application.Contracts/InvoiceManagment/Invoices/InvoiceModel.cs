using Forpost.Domain.InvoiceManagement;

namespace Forpost.Application.Contracts.InvoiceManagment.Invoices;

public sealed class InvoiceModel
{
    public Guid Id { get; set; }
    public string Number { get; set; } = null!;
    public Guid ContractorId { get; set; }
    public string ContractorName { get; set; } = null!;
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