using Forpost.Domain.ProductCreating.Issue;

namespace Forpost.Web.Contracts.Crm.InvoiceManagement.Invoices;

public class InvoiceUpdateRequest
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public Guid ContractorId { get; set; }
    public IssueStatus IssueStatus { get; set; }
    public string? Description { get; set; }
    public int? DaysShipment { get; set; }
    public int? PaymentPercentage { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
}