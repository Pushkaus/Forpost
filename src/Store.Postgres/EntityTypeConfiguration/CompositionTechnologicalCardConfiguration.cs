using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class CompositionTechnologicalCardConfiguration: IEntityTypeConfiguration<CompositionTechnologicalCard>
{
    public void Configure(EntityTypeBuilder<CompositionTechnologicalCard> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.HasOne<TechnologicalCard>()
            .WithOne()
            .HasForeignKey<CompositionTechnologicalCard>(key => key.TechnologicalCardId);
        
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);
    }
}