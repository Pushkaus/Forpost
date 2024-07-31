using Forpost.Common.EntityAnnotations;
using System.Collections.Generic;

namespace Forpost.Store.Entities
{
    public class Category : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        
        // Навигационные свойства
        public Category ParentCategory { get; set; }          // Родительская категория
        public ICollection<Category> SubCategories { get; set; }   // Дочерние категории
    }
}