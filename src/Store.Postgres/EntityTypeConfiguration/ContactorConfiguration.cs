using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ContactorConfiguration : IEntityTypeConfiguration<Contractor>
{
    public void Configure(EntityTypeBuilder<Contractor> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLength);
    }
}