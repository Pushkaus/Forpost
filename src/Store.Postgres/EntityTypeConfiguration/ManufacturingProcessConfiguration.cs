using Forpost.Store.Catalog;
using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ManufacturingProcessConfiguration: IEntityTypeConfiguration<ManufacturingProcess>
{
    public void Configure(EntityTypeBuilder<ManufacturingProcess> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechnologicalCard>()
            .WithMany()
            .HasForeignKey(key => key.TechnologicalCardId);
        
       
    }
}