using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class InvoiceProductConfiguration: IEntityTypeConfiguration<InvoiceProduct>
{
    public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(entity => entity.Invoice)
            .WithMany(entity => entity.InvoiceProducts)
            .HasForeignKey(entity => entity.InvoiceId);
        
        builder.HasOne(entity => entity.Product)
            .WithMany(entity => entity.InvoiceProducts)
            .HasForeignKey(entity => entity.ProductId);
            
    }
}