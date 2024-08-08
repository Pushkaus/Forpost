using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public sealed class Issue: IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Cost { get; set; }
    public IReadOnlyCollection<Operation> Operations { get; set; }
}