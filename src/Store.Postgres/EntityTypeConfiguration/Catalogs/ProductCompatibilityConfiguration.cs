using Forpost.Domain.Catalogs.Products.ProductCompatibilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.Catalogs;

internal sealed class ProductCompatibilityConfiguration: IEntityTypeConfiguration<ProductCompatibility>
{
    public void Configure(EntityTypeBuilder<ProductCompatibility> builder)
    {
        builder.ConfigureBaseEntity();
    }
}