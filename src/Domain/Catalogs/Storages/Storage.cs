using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Storages;

public sealed class Storage : DomainAuditableEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    /// <summary>
    /// Ответственный за склад
    /// </summary>
    public Guid ResponsibleId { get; set; }
}