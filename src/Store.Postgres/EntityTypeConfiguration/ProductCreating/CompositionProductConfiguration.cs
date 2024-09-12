using Forpost.Domain.ProductCreating.CompositionProduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.ProductCreating;

internal sealed class CompositionProductConfiguration: IEntityTypeConfiguration<CompositionProduct>
{
    public void Configure(EntityTypeBuilder<CompositionProduct> builder)
    {
        builder.ConfigureBaseEntity();
    }
}