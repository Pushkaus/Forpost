using Forpost.Domain.Sortout;

namespace Forpost.Application.SortOut;

public class InvoiceCreateCommand
{
    public string Number { get; set; } = default!;
    public Guid ContragentId { get; set; }
    public IssueStatus IssueStatus { get; set; }

    public string? Description { get; set; }
    public int? DaysShipment { get; set; }
    public int? PaymentPercentage { get; set; }
}