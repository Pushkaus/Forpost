using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ProductVersionConfiguration : IEntityTypeConfiguration<ProductVersionEntity>
{
    public void Configure(EntityTypeBuilder<ProductVersionEntity> builder)
    {
        builder.ConfigureBaseEntity();
        builder.HasOne<ProductEntity>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);
    }
}