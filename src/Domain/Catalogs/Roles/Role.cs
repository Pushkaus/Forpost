using Forpost.Common.EntityAnnotations;

namespace Forpost.Domain.Catalogs.Roles;

public sealed class Role : IEntity
{
    public string Name { get; set; } = null!;
    public Guid Id { get; set; }
}