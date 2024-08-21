using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class TechCardItemCardConfiguration : IEntityTypeConfiguration<TechCardItem>
{
    public void Configure(EntityTypeBuilder<TechCardItem> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCard>()
            .WithOne()
            .HasForeignKey<TechCardItem>(key => key.TechCardId);

        builder.HasOne<Product>()
            .WithOne()
            .HasForeignKey<TechCardItem>(key => key.ProductId);
    }
}