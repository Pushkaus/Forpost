using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.CRM.InvoiceManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.CRM.InvoicesManagment;

internal sealed class InvoiceProductConfiguration : IEntityTypeConfiguration<InvoiceProduct>
{
    public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<Invoice>()
            .WithMany()
            .HasForeignKey(key => key.InvoiceId);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);
    }
}