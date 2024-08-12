using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class TechnologicalCardConfiguration: IEntityTypeConfiguration<TechnologicalCard>
{
    public void Configure(EntityTypeBuilder<TechnologicalCard> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.HasOne<CompositionTechnologicalCard>()
            .WithOne()
            .HasForeignKey<TechnologicalCard>(key => key.CompositionTechonogicalCardId);

        builder.HasOne<Product>()
            .WithOne()
            .HasForeignKey<TechnologicalCard>(key => key.ProductId);
    }
}