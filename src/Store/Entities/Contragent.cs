using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class Contragent: IEntity
{
    public Contragent(string name)
    {
        Name = name;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
}