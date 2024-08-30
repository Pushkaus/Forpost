using Forpost.Domain.Primitives.EntityTemplates;
using Forpost.Domain.ProductCreating.Issue;

namespace Forpost.Domain.InvoiceManagement;

public sealed class Invoice : DomainAuditableEntity
{
    public void InitialAdd()
    {
        IssueStatus = IssueStatus.InProgress;
    }
    public string Number { get; set; } = null!;
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int PaymentPercentage { get; set; }
    public int DaysShipment { get; set; }
    public IssueStatus IssueStatus { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
}