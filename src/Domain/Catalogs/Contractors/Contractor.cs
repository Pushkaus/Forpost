using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.Catalogs.Contractors;

public sealed class Contractor : DomainEntity
{
    public string Name { get; private set; } = default!;
}