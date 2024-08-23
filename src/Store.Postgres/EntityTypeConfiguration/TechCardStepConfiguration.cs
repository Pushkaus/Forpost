using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class TechCardStepConfiguration : IEntityTypeConfiguration<TechCardStep>
{
    public void Configure(EntityTypeBuilder<TechCardStep> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCard>()
            .WithOne()
            .HasForeignKey<TechCardStep>(key => key.TechCardId);

        builder.HasOne<Step>()
            .WithOne()
            .HasForeignKey<TechCardStep>(key => key.StepId);
    }
}