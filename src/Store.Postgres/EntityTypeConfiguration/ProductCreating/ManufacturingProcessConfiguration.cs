using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.ProductCreating;

internal sealed class ManufacturingProcessConfiguration : IEntityTypeConfiguration<ManufacturingProcess>
{
    public void Configure(EntityTypeBuilder<ManufacturingProcess> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCard>()
            .WithMany()
            .HasForeignKey(key => key.TechnologicalCardId);

        builder.Property(entity => entity.BatchNumber).HasMaxLength(DatabaseConstrains.MaxLength);
    }
}