using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public sealed class ContactorConfiguration : IEntityTypeConfiguration<Contractor>
{
    public void Configure(EntityTypeBuilder<Contractor> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLenght);
    }
}