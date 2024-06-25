using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public sealed class ProductWorkConfiguration: IEntityTypeConfiguration<ProductWork>
{
    public void Configure(EntityTypeBuilder<ProductWork> builder)
    {
        builder.HasKey(pw => new { pw.WorkTypeId, pw.ProductId }); // Композитный ключ

        builder.HasOne(pw => pw.WorkType)
            .WithMany(wt => wt.ProductWorks)
            .HasForeignKey(pw => pw.WorkTypeId);

        builder.HasOne(pw => pw.Product)
            .WithMany(p => p.ProductWorks)
            .HasForeignKey(pw => pw.ProductId);
        
    }
}