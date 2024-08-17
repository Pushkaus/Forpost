using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class Storage: IAuditableEntity, IEntity
{
    private Storage() {}
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    /// <summary>
    /// Ответственный за склад
    /// </summary>
    public Guid ResponsibleId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
}