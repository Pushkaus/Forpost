using Forpost.Domain.Catalogs.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.Catalogs;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ConfigureBaseEntity();
        builder.HasIndex(entity => entity.Name).IsUnique();

        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLength);
    }
}