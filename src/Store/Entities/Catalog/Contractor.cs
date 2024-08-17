using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public sealed class Contractor: IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}