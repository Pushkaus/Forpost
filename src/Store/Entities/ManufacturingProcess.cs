using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities
{
    /// <summary>
    /// Производственный процесс
    /// </summary>
    public sealed class ManufacturingProcess: IEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string? Description { get; set; }
        public Guid ProductId { get; set; }
        public IReadOnlyCollection<Issue> Issues { get; set; }
    }
}

