using Forpost.Common.EntityAnnotations;

namespace Forpost.Domain.Catalogs.Contractors;

public sealed class Contractor : IEntity
{
    public string Name { get; private set; } = default!;
    public Guid Id { get; private set; }
}