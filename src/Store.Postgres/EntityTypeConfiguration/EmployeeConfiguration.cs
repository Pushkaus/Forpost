using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.HasOne<RoleEntity>()
            .WithMany()
            .HasForeignKey(key => key.RoleId);
        
        builder.Property(entity => entity.FirstName).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.LastName).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Patronymic).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Post).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Email).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.PhoneNumber).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.PasswordHash).HasMaxLength(DatabaseConstrains.MaxLength);



    }
}