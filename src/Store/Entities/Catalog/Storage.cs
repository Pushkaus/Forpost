using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class Storage : IAuditableEntity, IEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    /// <summary>
    ///     Ответственный за склад
    /// </summary>
    public Guid ResponsibleId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public Guid Id { get; set; }
}