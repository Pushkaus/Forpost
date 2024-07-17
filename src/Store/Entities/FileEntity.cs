using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class FileEntity: IEntity
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string ContentType { get; set; }
    public Guid ParentId { get; set; }
    
}