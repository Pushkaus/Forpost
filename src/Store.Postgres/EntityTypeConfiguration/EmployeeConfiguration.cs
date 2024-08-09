using Forpost.Store.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Postgres.EntityTypeConfiguration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ConfigureBaseEntity();

            builder.HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId);
            
            var hasher = new PasswordHasher<Employee>();
            var userId = Guid.NewGuid();
            builder.HasData(new Employee
            {
                Id = userId,
                FirstName = "test",
                LastName = "test",
                Patronymic = null,
                Post = "Administrator",
                RoleId = new Guid("05492e30-8df3-432f-9de6-3fcd91e389f5"),
                Email = "default@employee.com",
                PhoneNumber = "1234567890",
                PasswordHash = hasher.HashPassword(null, "123"),
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedById = userId,
                UpdatedAt = DateTimeOffset.UtcNow,
                UpdatedById = userId
            });
        }
    }
}
