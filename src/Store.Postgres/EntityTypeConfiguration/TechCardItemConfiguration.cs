using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class TechCardItemConfiguration : IEntityTypeConfiguration<TechCardItem>
{
    public void Configure(EntityTypeBuilder<TechCardItem> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCard>()
            .WithMany()
            .HasForeignKey(key => key.TechCardId);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);
    }
}