using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Common.EntityAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Forpost.Store.Entities
{
    public sealed class Role: IEntity
    {
        public Role(string name)
        {
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Навигационные свойства
        public IReadOnlyCollection<Employee> Employees { get; set; }
    }
}
