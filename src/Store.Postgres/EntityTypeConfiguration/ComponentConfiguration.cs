using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public sealed class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        // Композитный ключ
        builder.HasKey(sp => new { sp.ParentId, sp.DaughterId });

        // Связи с навигационными свойствами
        builder
            .HasOne(sp => sp.ParentProduct)
            .WithMany(p => p.ParentSubProducts)
            .HasForeignKey(sp => sp.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(sp => sp.DaughterProduct)
            .WithMany(p => p.DaughterSubProducts)
            .HasForeignKey(sp => sp.DaughterId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}