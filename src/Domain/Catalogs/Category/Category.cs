using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.Catalogs.Category;

public sealed class Category : DomainEntity
{
    public string Name { get; set; } = null!;
    public Guid? ParentId { get; set; }
}