using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Domain.ProductCreating.CompositionCompletedProduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class CompositionCompletedProductConfiguration: IEntityTypeConfiguration<CompositionCompletedProduct>
{
    public void Configure(EntityTypeBuilder<CompositionCompletedProduct> builder)
    {
        builder.ConfigureBaseEntity();
    }
}