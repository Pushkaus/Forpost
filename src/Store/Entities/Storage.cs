namespace Forpost.Store.Entities;

public class Storage
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Assembly> Assemblies { get; set; }
}