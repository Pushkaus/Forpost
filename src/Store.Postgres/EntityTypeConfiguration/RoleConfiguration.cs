using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLenght);
    }
}