using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class InvoiceProductConfiguration : IEntityTypeConfiguration<InvoiceProductEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceProductEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<InvoiceEntity>()
            .WithMany()
            .HasForeignKey(key => key.InvoiceId);

        builder.HasOne<ProductEntity>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);
    }
}