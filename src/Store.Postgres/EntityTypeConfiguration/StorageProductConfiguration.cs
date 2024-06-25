using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public sealed class StorageProductConfiguration: IEntityTypeConfiguration<StorageProduct>
{
    public void Configure(EntityTypeBuilder<StorageProduct> builder)
    {
        builder.HasKey(sp => new { sp.ProductId, sp.StorageId });

        // Настройка связи многие к одному
        builder.HasOne(sp => sp.Storage)
            .WithMany(s => s.StorageProducts)
            .HasForeignKey(sp => sp.StorageId)
            .OnDelete(DeleteBehavior.Cascade); // Обновлено

        // Настройка связи многие к одному
        builder.HasOne(sp => sp.Product)
            .WithMany(p => p.StorageProducts)
            .HasForeignKey(sp => sp.ProductId)
            .OnDelete(DeleteBehavior.Cascade); // Обновлено

        // Индекс для оптимизации запросов
        builder.HasIndex(sp => new { sp.ProductId, sp.StorageId }).IsUnique();
    }
    
}