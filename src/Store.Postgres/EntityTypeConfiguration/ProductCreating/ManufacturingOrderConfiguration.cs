using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.ProductCreating;

internal sealed class ManufacturingOrderConfiguration: IEntityTypeConfiguration<ManufacturingOrder>
{
    public void Configure(EntityTypeBuilder<ManufacturingOrder> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(entity => entity.ManufacturingOrderStatus)
            .ConfigureSmartEnumerationAsEnum();
    }
}