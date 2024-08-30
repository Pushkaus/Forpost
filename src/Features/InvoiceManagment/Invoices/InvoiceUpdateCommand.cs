using Forpost.Domain.ProductCreating.Issue;

namespace Forpost.Features.InvoiceManagment.Invoices;

public class InvoiceUpdateCommand
{
    public Guid Id { get; set; }
    public string Number { get; set; } = default!;
    public Guid ContractorId { get; set; }
    public string? Description { get; set; }
    public IssueStatus IssueStatus { get; set; }
    public int? DaysShipment { get; set; }
    public int? PaymentPercentage { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
}