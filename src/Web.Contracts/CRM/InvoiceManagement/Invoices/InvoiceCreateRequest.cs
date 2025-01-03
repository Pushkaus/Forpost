using Forpost.Features.Crm.InvoiceManagement.Invoices;

namespace Forpost.Web.Contracts.Crm.InvoiceManagement.Invoices;

/// <summary>
/// Модель запроса на создание счета
/// </summary>
public class InvoiceCreateRequest
{
    public string Number { get; set; } = default!;
    public Guid ContractorId { get; set; }
    public string? Description { get; set; }
    public int Priority { get; set; }
    public int PaymentStatus { get; set; }
    public DateTimeOffset PaymentDeadline { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public decimal? PaymentPercentage { get; set; } 
    public IReadOnlyCollection<InvoiceProductCreate> Products { get; set; } =
        new List<InvoiceProductCreate>(); 
}
