using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
        
        builder.HasMany(entity => entity.InvoiceProducts)
            .WithOne(entity => entity.Product)
            .HasForeignKey(entity => entity.ProductId);
        
        builder.HasMany(p => p.ParentSubProducts)
            .WithOne(sub => sub.ParentProduct)
            .HasForeignKey(sub => sub.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.DaughterSubProducts)
            .WithOne(sub => sub.DaughterProduct)
            .HasForeignKey(sub => sub.DaughterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}