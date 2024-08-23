using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class FileEntity : IEntity
{
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public Guid ParentId { get; set; }
    public Guid Id { get; set; }
}