using Forpost.Store.Catalog;
using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class CompositionTechnologicalCardConfiguration: IEntityTypeConfiguration<TechCardItem>
{
    public void Configure(EntityTypeBuilder<TechCardItem> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.HasOne<TechCard>()
            .WithOne()
            .HasForeignKey<TechCardItem>(key => key.TechnologicalCardId);
        
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);
    }
}