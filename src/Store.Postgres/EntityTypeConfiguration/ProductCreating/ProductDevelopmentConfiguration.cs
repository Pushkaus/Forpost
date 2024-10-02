using Forpost.Domain.ProductCreating.ProductDevelopment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.ProductCreating;

internal sealed class ProductDevelopmentConfiguration : IEntityTypeConfiguration<ProductDevelopment>
{
    public void Configure(EntityTypeBuilder<ProductDevelopment> builder)
    {
        builder.ConfigureBaseEntity();
    }
}