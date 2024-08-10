using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities
{
    /// <summary>
    /// Технологическая карта
    /// </summary>
    public sealed class TechnologicalCard: IEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string? Description { get; set; }
        public Guid ProductId { get; set; }
    }
}

