using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class StorageProductConfiguration : IEntityTypeConfiguration<StorageProductEntity>
{
    public void Configure(EntityTypeBuilder<StorageProductEntity> builder)
    {
        builder.HasKey(sp => new { sp.ProductId, sp.StorageId });

        builder.HasOne<StorageEntity>()
            .WithMany()
            .HasForeignKey(key => key.StorageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ProductEntity>()
            .WithMany()
            .HasForeignKey(key => key.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Индекс для оптимизации запросов
        builder.HasIndex(sp => new { sp.ProductId, sp.StorageId }).IsUnique();
    }
}