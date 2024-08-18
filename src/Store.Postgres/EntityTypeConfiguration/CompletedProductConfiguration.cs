using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class CompletedProductConfiguration : IEntityTypeConfiguration<CompletedProduct>
{
    public void Configure(EntityTypeBuilder<CompletedProduct> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);

        builder.HasOne<ManufacturingProcess>()
            .WithOne()
            .HasForeignKey<CompletedProduct>(key => key.ManufacturingProcessId);
        
        builder.Property(entity => entity.SerialNumber).HasMaxLength(DatabaseConstrains.MaxLenght);

    }
}