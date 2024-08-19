using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public class StepConfiguration : IEntityTypeConfiguration<Step>
{
    public void Configure(EntityTypeBuilder<Step> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<Operation>()
            .WithOne()
            .HasForeignKey<Step>(entity => entity.OperationId);

        builder.HasOne<TechCard>()
            .WithMany()
            .HasForeignKey(key => key.TechCardId);
        
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLenght);

    }
}