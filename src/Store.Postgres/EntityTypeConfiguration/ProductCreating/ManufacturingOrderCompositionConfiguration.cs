using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.ProductCreating;

internal sealed class
    ManufacturingOrderCompositionConfiguration : IEntityTypeConfiguration<ManufacturingOrderComposition>
{
    public void Configure(EntityTypeBuilder<ManufacturingOrderComposition> builder)
    {
        builder.ConfigureBaseEntity();
    }
}