using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.FileStorage;

public sealed class File : DomainEntity
{
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public Guid ParentId { get; set; }
}