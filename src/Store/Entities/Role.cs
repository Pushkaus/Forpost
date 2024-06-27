using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Forpost.Store.Entities
{
    public sealed class Role
    {
        public Role(string name)
        {
            Name = name;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Навигационные свойства
        public ICollection<Employee> Employees { get; set; }
    }
}
