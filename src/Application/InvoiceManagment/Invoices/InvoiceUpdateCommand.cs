using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.Sortout;

namespace Forpost.Application.SortOut;

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