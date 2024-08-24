using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class TechCardItemConfiguration : IEntityTypeConfiguration<TechCardItemEntity>
{
    public void Configure(EntityTypeBuilder<TechCardItemEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCardEntity>()
            .WithMany()
            .HasForeignKey(key => key.TechCardId);

        builder.HasOne<ProductEntity>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);
    }
}