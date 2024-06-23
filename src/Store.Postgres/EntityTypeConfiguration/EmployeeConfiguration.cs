using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Postgres.EntityTypeConfiguration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).ValueGeneratedNever();
            builder.HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId);
        }
    }
}
