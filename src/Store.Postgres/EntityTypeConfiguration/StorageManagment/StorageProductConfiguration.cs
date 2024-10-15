using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.Storages;
using Forpost.Domain.StorageManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.StorageManagment;

internal sealed class StorageProductConfiguration : IEntityTypeConfiguration<StorageProduct>
{
    public void Configure(EntityTypeBuilder<StorageProduct> builder)
    {
        builder.HasKey(sp => new { sp.ProductId, sp.StorageId });

        builder.HasOne<Storage>()
            .WithMany()
            .HasForeignKey(key => key.StorageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(key => key.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Индекс для оптимизации запросов
        builder.HasIndex(sp => new { sp.ProductId, sp.StorageId }).IsUnique();
    }
}