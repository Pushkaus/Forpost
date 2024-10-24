using Forpost.Domain.CRM.InvoiceManagement;

namespace Forpost.Web.Contracts.CRM.InvoiceManagement.Invoices;

/// <summary>
/// Модель запроса на создание счета
/// </summary>
public class InvoiceCreateRequest
{
    public string Number { get; set; }
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int DaysShipment { get; set; }
    public decimal PaymentPercentage { get; set; }
    public IReadOnlyList<InvoiceProduct> Products { get; set; } = Array.Empty<InvoiceProduct>();
}