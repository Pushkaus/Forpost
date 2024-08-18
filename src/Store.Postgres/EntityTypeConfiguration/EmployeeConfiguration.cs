using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ConfigureBaseEntity();
        builder.HasOne<Role>()
            .WithMany()
            .HasForeignKey(key => key.RoleId);
        
        builder.Property(entity => entity.FirstName).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.LastName).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.Patronymic).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.Post).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.Email).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.PhoneNumber).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.PasswordHash).HasMaxLength(DatabaseConstrains.MaxLenght);



    }
}