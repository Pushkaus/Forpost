using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
        builder.HasIndex(entity => new { entity.Name, entity.Version });
        builder.HasMany(entity => entity.InvoiceProducts)
            .WithOne(entity => entity.Product)
            .HasForeignKey(entity => entity.ProductId);
        builder.HasMany(p => p.ProductOperations)
            .WithOne(pw => pw.Product)
            .HasForeignKey(pw => pw.ProductId);
        // Связь один ко многим через ParentId
        builder.HasMany(p => p.ParentSubProducts)
            .WithOne(sub => sub.ParentProduct)
            .HasForeignKey(sub => sub.ParentId);

        // Связь один ко многим через DaughterId
        builder.HasMany(p => p.DaughterSubProducts)
            .WithOne(sub => sub.DaughterProduct)
            .HasForeignKey(sub => sub.DaughterId);
    }   
}