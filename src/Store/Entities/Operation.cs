using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class Operation: IEntity
{
    public Operation()
    {
        
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
}