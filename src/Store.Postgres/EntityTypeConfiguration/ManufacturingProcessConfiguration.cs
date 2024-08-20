using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Entities.ProductCreating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ManufacturingProcessConfiguration : IEntityTypeConfiguration<ManufacturingProcess>
{
    public void Configure(EntityTypeBuilder<ManufacturingProcess> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCard>()
            .WithMany()
            .HasForeignKey(key => key.TechnologicalCardId);
        
        builder.Property(entity => entity.BatchNumber).HasMaxLength(DatabaseConstrains.MaxLenght);

    }
}