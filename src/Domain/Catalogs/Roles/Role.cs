using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.Catalogs.Roles;

public sealed class Role : DomainEntity
{
    public string Name { get; set; } = null!;
}