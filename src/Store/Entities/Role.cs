using Microsoft.AspNetCore.Identity;

namespace Forpost.Store.Entities
{
    public sealed class Role
    {
        public Role(Guid id, string name)
        {
            Id = new Guid();
            Name = name;
        }

        public Role()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        // Навигационные свойства
        public ICollection<Employee> Employees { get; set; }
    }
}
