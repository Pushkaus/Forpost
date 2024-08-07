using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public class IssueInstance: IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid ManufacturingProcessInstanceId { get; set; }
    public Guid ResponsibleEmployeeId { get; set; }
    public Issue Template { get; set; } = null!;
    public IReadOnlyCollection<IssueInstance> PreviosIssues { get; set; } = Array.Empty<IssueInstance>();
    public IssueInstance? NextIssue { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public ManufacturingProcessIstance ManufacturingProcessIstance { get; set; } = null!;
}