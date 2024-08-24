using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class TechCardStepConfiguration : IEntityTypeConfiguration<TechCardStepEntity>
{
    public void Configure(EntityTypeBuilder<TechCardStepEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCardEntity>()
            .WithMany()
            .HasForeignKey(key => key.TechCardId);

        builder.HasOne<StepEntity>()
            .WithMany()
            .HasForeignKey(key => key.StepId);
    }
}