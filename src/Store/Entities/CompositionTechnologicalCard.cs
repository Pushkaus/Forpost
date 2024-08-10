using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class CompositionTechnologicalCard: IEntity
{
    public Guid Id { get; set; }
    public Guid TechnologicalCardId { get; set; }
    public Guid ProductId { get; set; }
}