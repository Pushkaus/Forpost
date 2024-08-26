using Forpost.Common.EntityAnnotations;
using Forpost.Domain.ProductCreating.Issue;

namespace Forpost.Domain.Sortout;

public sealed class Invoice : IAuditableEntity, IEntity
{
    public string Number { get; set; } = null!;
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int PaymentPercentage { get; set; }
    public int DaysShipment { get; set; }
    public IssueStatus IssueStatus { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }

    public Guid Id { get; set; }
}