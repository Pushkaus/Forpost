using Forpost.Domain.ProductCreating.Issue;

namespace Forpost.Web.Contracts.Crm.InvoiceManagement.Invoices;

public class InvoiceResponse
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int PaymentPercentage { get; set; }
    public int DaysShipment { get; set; }
    public IssueStatus IssueStatus { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
    public Guid? PaymentId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
}