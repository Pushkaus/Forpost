using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class CompletedProductConfiguration : IEntityTypeConfiguration<CompletedProduct>
{
    public void Configure(EntityTypeBuilder<CompletedProduct> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<ProductDevelopment>()
            .WithMany()
            .HasForeignKey(key => key.ProductDevelopmentId);

        builder.HasOne<ManufacturingProcess>()
            .WithOne()
            .HasForeignKey<CompletedProduct>(key => key.ManufacturingProcessId);
    }
}