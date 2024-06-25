using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public sealed class SubProductConfiguration: IEntityTypeConfiguration<SubProduct>
{
    public void Configure(EntityTypeBuilder<SubProduct> builder)
    {
        // Композитный ключ
        builder.HasKey(sp => new { sp.ParentId, sp.DaughterId });
        


        // Индекс для оптимизации запросов
    }
}