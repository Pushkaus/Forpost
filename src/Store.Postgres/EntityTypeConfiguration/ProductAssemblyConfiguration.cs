using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Entities;

internal sealed class ProductAssemblyConfiguration: IEntityTypeConfiguration<ProductAssembly>
{
    public void Configure(EntityTypeBuilder<ProductAssembly> builder)
    {
        builder.HasKey(pa => new { pa.ProductId, pa.AssemblyId });  // Определение составного первичного ключа

        builder.HasOne(pa => pa.Product)
            .WithMany(p => p.ProductAssemblies)
            .HasForeignKey(pa => pa.ProductId);

        builder.HasOne(pa => pa.Assembly)
            .WithMany(a => a.ProductAssemblies)
            .HasForeignKey(pa => pa.AssemblyId);
    }
}