using Forpost.Domain.ProductCreating.Issue;

namespace Forpost.Application.InvoiceManagment.Invoices;

public class InvoiceCreateCommand
{
    public string Number { get; set; } = default!;
    public Guid ContragentId { get; set; }
    public IssueStatus IssueStatus { get; set; }

    public string? Description { get; set; }
    public int? DaysShipment { get; set; }
    public int? PaymentPercentage { get; set; }
}