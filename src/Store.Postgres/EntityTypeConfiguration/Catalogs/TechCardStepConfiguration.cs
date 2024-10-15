using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCardSteps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.Catalogs;

internal sealed class TechCardStepConfiguration : IEntityTypeConfiguration<TechCardStep>
{
    public void Configure(EntityTypeBuilder<TechCardStep> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCard>()
            .WithMany()
            .HasForeignKey(key => key.TechCardId);

        builder.HasOne<Step>()
            .WithMany()
            .HasForeignKey(key => key.StepId);
    }
}