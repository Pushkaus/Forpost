using Forpost.Common.EntityAnnotations;
using System.Collections.Generic;

namespace Forpost.Store.Entities;

public sealed class Category : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}