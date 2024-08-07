using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class ManufacturingProcessIstance: IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public ManufacturingProcess Template { get; set; } = null!;
    public int BatchNumber { get; set; }
    public int TargetQuantity { get; set; }
    public int CurrentQuantity { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public IReadOnlyCollection<IssueInstance> IssuesInstances { get; set; }
    public IReadOnlyCollection<Operation> Operations { get; set; }
    public IReadOnlyCollection<ManufacturingProcessIstance> SubProcessesIstances { get; set; }
}