using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.Sortout;

namespace Forpost.Web.Contracts.Models.Invoices;

/// <summary>
/// Модель запроса на создание счета
/// </summary>
public class InvoiceCreateRequest
{
    public string Number { get; set; }
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int? DaysShipment { get; set; }
    public int? PaymentPercentage { get; set; }
}