using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public sealed class Contractor : IEntity
{
    public string Name { get; set; } = null!;
    public Guid Id { get; set; }
}