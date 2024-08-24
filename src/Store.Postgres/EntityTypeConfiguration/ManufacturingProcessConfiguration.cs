using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Entities.ProductCreating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ManufacturingProcessConfiguration : IEntityTypeConfiguration<ManufacturingProcessEntity>
{
    public void Configure(EntityTypeBuilder<ManufacturingProcessEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCardEntity>()
            .WithMany()
            .HasForeignKey(key => key.TechnologicalCardId);
        
        builder.Property(entity => entity.BatchNumber).HasMaxLength(DatabaseConstrains.MaxLength);

    }
}