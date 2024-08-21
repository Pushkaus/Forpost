using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLength);
    }
}