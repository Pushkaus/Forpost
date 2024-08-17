using Forpost.Store.Catalog;
using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class TechnologicalCardConfiguration: IEntityTypeConfiguration<TechCard>
{
    public void Configure(EntityTypeBuilder<TechCard> builder)
    {
        builder.ConfigureBaseEntity();
        
        

        builder.HasOne<Product>()
            .WithOne()
            .HasForeignKey<TechCard>(key => key.ProductId);
    }
}