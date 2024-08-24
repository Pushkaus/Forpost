using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Entities.ProductCreating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class CompletedProductConfiguration : IEntityTypeConfiguration<CompletedProductEntity>
{
    public void Configure(EntityTypeBuilder<CompletedProductEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<ProductEntity>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);

        builder.HasOne<ManufacturingProcessEntity>()
            .WithOne()
            .HasForeignKey<CompletedProductEntity>(key => key.ManufacturingProcessId);
        
        builder.Property(entity => entity.SerialNumber).HasMaxLength(DatabaseConstrains.MaxLength);

    }
}