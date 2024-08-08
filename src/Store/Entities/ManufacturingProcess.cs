using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities
{
    /// <summary>
    /// Производственный процесс
    /// </summary>
    public sealed class ManufacturingProcess: IEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string? Description { get; set; }
        public Guid ProductId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid CreatedById { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public Guid UpdatedById { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public Guid? DeletedById { get; set; }
        public IReadOnlyCollection<Issue> Issues { get; set; }
    }
}

